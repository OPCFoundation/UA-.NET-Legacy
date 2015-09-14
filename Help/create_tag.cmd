rem//  $LastChangedDate: 2009-02-05 10:28:28 +0200 (Thu, 05 Feb 2009) $
rem//  $Rev: 463 $
rem//  $LastChangedBy: mpostol#cas.com.pl $
rem//  $URL: https://www.opcfoundation.org:8443/svn/repo1/UA/Help/trunk/create_tag.cmd $
rem//  $Id: create_tag.cmd 463 2009-02-05 08:28:28Z mpostol#cas.com.pl $
if "%1"=="" goto ERROR
svn copy https://www.opcfoundation.org:8443/svn/repo1/UA/Help/trunk https://www.opcfoundation.org:8443/svn/repo1/UA/Help/tags/%1 -m "created new tag %1"


goto EXIT
:ERROR
echo Parametr (release version) must be set
:EXIT
