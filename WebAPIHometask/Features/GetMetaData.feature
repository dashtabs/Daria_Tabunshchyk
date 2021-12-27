Feature: 2GetFileMetadata
	Get meta of a file on Dropbox

Scenario: Get this meta!
	Given There is an /WebAPIHometask/image.jpg on Dropbox
	When POST request  is sent to https://api.dropboxapi.com/2/sharing/get_file_metadata
	Then The response should be with /WebAPIHometask/image.jpg in contents
