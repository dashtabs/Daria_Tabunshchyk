# Selenium WebAPI tests 

Referring to this API: https://www.dropbox.com/developers/documentation/http/documentation

## Run tests
Open the project in Visual Studio. Open your test explorer. Features are named in alphabetical order, so you can just click `run all tests`. To generate the Allure report, you might need to install `Allure` and `scoop`.

## Allure
To connect report, I created `Allure-Report` and `Allure-Results` folders. I also added an `AllureNUnit` package and opened `Windows Powershell` and typed the following commands:
`set-executionpolicy RemoteSigned -scope CurrentUser`
`scoop install allure` 
If you get an error that there is no `scoop` command, type `Invoke-Expression (New-Object System.Net.WebClient).DownloadString('https://get.scoop.sh')` and repeat the previous two commands. 
### You don't previous steps if Allure is already installed. 
I've also created `Allureconfig.json` file in `WebAPIHometask\WebAPIHometask\bin\Debug\netcoreapp3.1` directory with the following contents:
```JSON
{
  "allure": {
    "directory": "C:\\Users\\dasha\\source\\repos\\WebAPIHometask\\WebAPIHometask\\Allure-Results",
    "links": [
      "https://github.com/AutomateThePlanet/Meissa/issues/{issue}",
      "https://github.com/AutomateThePlanet/Meissa/projects/2#card-{tms}",
      "{link}"
    ]
  }
}
```
### You need to change path to the Allure-Results folder according to where it is located on your computer.

And I've created `categories` file in the same directory with the following contents:
```JSON
[
  {
    "name": "Ignored tests",
    "matchedStatuses": [ "skipped" ]
  },
  {
    "name": "Product Bug",
    "matchedStatuses": [ "broken", "failed" ],
    "messageRegex": ".*AssertionExeption.*"
  }
]
```
Check that these files are in `netccoreapp3.1` and that your path to the file in `Allureconfig.json` is written correctly.
Open `Powershell` and type `allure serve` and path to your `Allure Results` folder. Execute and you'll see the Allure report.

## Run from command line
To run from command line in a proper order go to OrangeTests->OrangeTests->bin->Debug->netcoreapp3.1 and type `cmd` in the address line. Then paste the following command: 
`dotnet vstest WebAPIHometask.dll /Tests:UploadAPicture,GetThisMeta,DeleteThisImage`

## Preparations
We work with a Page Builder model. Here we need Authorization class to not repeat the token every time and Headers to set keys and values. Then we make an abstract class Builder and three classes that inherit it: `Upload`, `GetMetaData` and `Delete`.
Each one is created for the corresponding request. And, finally, a `Request`class:
```C#
class Request
    {
        public Builder builder;
        public Request(Builder rb)
        {
            this.builder = rb;
        }
        public RestRequest Build(string body, List<Header> headers)
        {
            builder.setAuth();
            builder.addBody(body);
            builder.addHeaders(headers);
            return builder.Get();
        }
    }
```


## Task 1
##### Upload
All we need to do is specify which file to upload, where to upload and the request itself. Then we check is the response we got is `200OK`.

## Task 2
##### GetFileMetadata
Same situation here, but different header.

## Task 3
##### Delete file
Same as GetFileMetadata.

All the differences are specified in `Builder` file.
