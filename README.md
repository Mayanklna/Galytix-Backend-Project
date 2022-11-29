# Galytix-Backend-Project
Backend assignment

# Setup instructions:

- Clone this repository to a folder on your device.

- Run code from VisualStudio2019 Runner and Debugger.
- Post request to /api/gwp/avg/ route:
```
1. CsvData: Class for reading csv
2. InputData: Reading InputData Class from request
3. GetDataFromDB: Reads and returns avgerage from CSV
4. GetData: Function for the route, has try/catch in case of errors,
		Reads from csv and returns average as status code 201. If bad request
		return 500.
```
- You are ready to use the app! Bon testing :)
