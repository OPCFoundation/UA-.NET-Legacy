/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

#include "RandomGenerator.h"

// warning C4996: '_wfopen' was declared deprecated
#pragma warning (disable : 4996)

/* FILE API */
#include <stdio.h>

/* malloc, free API */
#include <stdlib.h>

/**
 * Random data source structure.
 * RANDOM variables will point to memory of this layout type.
 *
 */
typedef struct _RandomDataSource {
	/**
	 * FILE handle to for random data disk file.
	 */
	FILE * m_pFile;
	/**
	 * Seed to use for random data generation.
	 */
	long m_nSeed;
	/**
	 * Step to use for random data generation.
	 */
	long m_nStep;
	/**
	 * Position in file (not necessary, can be obtained by use of FILE API; useful to decrease number of FILE API calls.
	 */
	long m_nPositionInFile;
	/**
	 * Size of file (not necessary, can be obtained by use of FILE API; useful to decrease number of FILE API calls.
	 */
	long m_nSizeOfFile;

} RandomDataSource;

/**
 * Copies and swaps the bytes (used for little endian to big endian conversions).
 */
#ifdef USE_BIGENDIAN
#define CopyAndSwapBytes(xDst, xSrc, xLength) \
{ \
	int ii; \
	int nLength = xLength; \
 \
	for (ii = 0; ii < nLength; ii++) \
	{ \
		((unsigned char*)(xDst))[nLength-ii-1] = ((unsigned char*)(xSrc))[ii]; \
	} \
}
#else
#define CopyAndSwapBytes(xDst, xSrc, xLength) memcpy((unsigned char*)(xDst), (unsigned char*)(xSrc), xLength);
#endif

RANDOMGENERATOR_API int RandomCreate (RANDOM * pRandom, const char * pPathToFile, long nSeed, long nStep) {
	/* local variables */
	FILE * pFile;
	long nSizeOfFile;
	long nPositionInFile;
	RandomDataSource * pRandomDataSource;
	/* argument validation */
	if ((NULL == pRandom) || (NULL == pPathToFile) || (0 == nStep)) {
		return 1;
	}
	/* open file containing random data */
	pFile = fopen (pPathToFile, "rb");
	if (NULL == pFile) {
		return 2;
	}
	/* get file size */
	fseek (pFile, 0, SEEK_END);
	nSizeOfFile = ftell (pFile);
	if (0 >= nSizeOfFile) {
		fclose (pFile);
		return 3;
	}
	/* allocate memory for RandomDataSource storage */
	pRandomDataSource = (RandomDataSource *) malloc (sizeof (RandomDataSource));
	if (NULL == pRandomDataSource) {
		fclose (pFile);
		return 4;
	}
	
	/* compute initial position */
	nPositionInFile = nSeed % nSizeOfFile;

	/* fill RandomSource storage */
	pRandomDataSource->m_nPositionInFile = nPositionInFile;
	pRandomDataSource->m_nSeed = nSeed;
	pRandomDataSource->m_nSizeOfFile = nSizeOfFile;
	pRandomDataSource->m_nStep = nStep;
	pRandomDataSource->m_pFile = pFile;
	/* set random argument variable */
	* pRandom = pRandomDataSource;
	return 0;
}

RANDOMGENERATOR_API int RandomGetValue (RANDOM random, unsigned char * pData, long nCount) {
	/* local variables */
	FILE * pFile;
	long nPositionInFile;
	long nSizeOfFile;
	long nStep;
	long nSaveCount;
	RandomDataSource * pRandomDataSource;
	long nAvailable;
	/* check arguments */
	if ((NULL == random) || (NULL == pData) || (0 >= nCount)) {
		return 1;
	}
	/* get step, file, position in file and file size from random */
	pRandomDataSource = (RandomDataSource *) random;
	nStep = pRandomDataSource->m_nStep;
	pFile = pRandomDataSource->m_pFile;
	nPositionInFile = pRandomDataSource->m_nPositionInFile;
	nSizeOfFile = pRandomDataSource->m_nSizeOfFile;
	nSaveCount = nCount;
	while (0 < nCount) {
		/* seek in file from start of file to offset nPosition in file */
		fseek (pFile, nPositionInFile, SEEK_SET);
		/* read available data */
		nAvailable = nSizeOfFile - nPositionInFile;
		if (nAvailable > nCount) {
			nAvailable = nCount;
		}
		fread (pData, 1, nAvailable, pFile);
		pData += nAvailable;
		if (0 != ferror (pFile)) {
			return 2;
		}
		/* update left to read */
		nCount -= nAvailable;
		/* cycle position in file */
		nPositionInFile = (nPositionInFile + nAvailable) % nSizeOfFile;
	}

	/* move right step positions */
	nPositionInFile = (nPositionInFile + nSaveCount % nStep) % nSizeOfFile;
	/* set file position in random */
	pRandomDataSource->m_nPositionInFile = nPositionInFile;
	return 0;
}

RANDOMGENERATOR_API int RandomDestroy (RANDOM * random) {
	RandomDataSource * pRandomDataSource;
	if (NULL == random) {
		return 1;
	}
	/* allow NULL */
	if (NULL != * random) {
		pRandomDataSource = (RandomDataSource *) (* random);
		/* close file handle */
		fclose (pRandomDataSource->m_pFile);
		/* free memory */
		free (pRandomDataSource);
		/* set to NULL */
		* random = NULL;
	}
	return 0;
}

RANDOMGENERATOR_API char GetValueInt8(RANDOM* pRandom) 
{
	unsigned char nValue;
	
	if (RandomGetValue(pRandom, &nValue, sizeof(char)) != 0)
	{
		return 0;
	}
	
	return nValue;
}

RANDOMGENERATOR_API short GetValueInt16(RANDOM* pRandom) 
{
	short nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(short)) == 0)
	{
		short nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(short));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API int GetValueInt32(RANDOM* pRandom) 
{
	int nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(int)) == 0)
	{
		int nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(int));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API __int64 GetValueInt64(RANDOM* pRandom) 
{
	__int64 nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(__int64)) == 0)
	{
		__int64 nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(__int64));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API unsigned char  GetValueUInt8(RANDOM* pRandom)
{
	unsigned char nValue;
	
	if (RandomGetValue(pRandom, &nValue, sizeof(unsigned char)) != 0)
	{
		return 0;
	}
	
	return nValue;
}

RANDOMGENERATOR_API unsigned short GetValueUInt16(RANDOM* pRandom) 
{
	unsigned short nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(unsigned short)) == 0)
	{
		unsigned short nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(unsigned short));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API unsigned int GetValueUInt32(RANDOM* pRandom) 
{
	unsigned int nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(unsigned int)) == 0)
	{
		unsigned int nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(unsigned int));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API unsigned __int64 GetValueUInt64(RANDOM* pRandom) 
{
	unsigned __int64 nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(unsigned __int64)) == 0)
	{
		unsigned __int64 nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(unsigned __int64));			
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API float GetValueFloat(RANDOM* pRandom) 
{
	float nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(float)) == 0)
	{
		float nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(float));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API double GetValueDouble(RANDOM* pRandom) 
{
	double nRawValue;
	unsigned char* pData = (unsigned char*)&nRawValue;
	
	if (RandomGetValue(pRandom, pData, sizeof(double)) == 0)
	{
		double nValue;
		CopyAndSwapBytes(&nValue, pData, sizeof(double));
		return nValue;
	}
	
	return 0;
}

RANDOMGENERATOR_API __int64 GetValueDateTime(RANDOM* pRandom) 
{
	/*
	 * 1900 01 01 00 00 00 [ 94354848000000000LL ]
	 * 2100 01 01 00 00 00 [ 157469184000000000LL ]	 
	 */
	unsigned __int64 const nStartTime = 94354848000000000LL;
	unsigned __int64 const nStopTime  = 157469184000000000LL;
	unsigned __int64 const nDifference = nStopTime - nStartTime;

	unsigned __int64 nLong = GetValueInt64(pRandom);
	
	nLong %= nDifference;
	nLong += nStartTime;

	return (__int64)nLong;
}

RANDOMGENERATOR_API wchar_t* GetValueString(RANDOM* pRandom, wchar_t* pString, int nSize)
{
	unsigned short const nLeftRange  = 0x0020;
	unsigned short const nRightRange = 0x33ff; // 0x007E;
	unsigned short const nDifference = nRightRange - nLeftRange + 1;

	unsigned int ii;
	unsigned int nLength;

	if (nSize <= 0)
	{
		pString[0] = 0;
		return pString;
	}
		
	nLength = (GetValueUInt32(pRandom)%(unsigned int)(nSize-1))+1;

	for (ii = 0; ii < nLength; ii++) 
	{
		do 
		{
            unsigned short nChar = 0;

            do 
            {
			    nChar = GetValueUInt16(pRandom);

			    nChar %= nDifference;
			    nChar = nChar + nLeftRange;
    		
			    pString[ii] = (wchar_t)nChar;
            }
            while (iswcntrl(nChar));

			/* ensure the string has no leading or trailing spaces. */
			if (!iswspace(nChar))
			{
				break;
			}
		}
		while (ii == 0 || ii == nLength-1);
	}

	pString[nLength] = 0;

	return pString;
}
