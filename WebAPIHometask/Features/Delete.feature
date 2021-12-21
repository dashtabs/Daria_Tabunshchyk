Feature: 3DeleteFile
	Just delete a file from Dropbox!

Scenario: Delete this image!
	Given There is a /WebAPIHometask/image.jpg on Dropbox
	When I send a POST request to https://api.dropboxapi.com/2/files/delete_v2
	Then The response must be 200 OK