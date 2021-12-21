Feature: 1UploadFile
	Upload a file to Dropbox

Scenario: Upload a picture
	Given I have an image.jpg i want to upload to /WebAPIHometask/image.jpg
	When I send POST request to Dropbox https://content.dropboxapi.com/2/files/upload
	Then I should get response 200 OK
