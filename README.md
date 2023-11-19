# Student Fee Payment
Welcome to 'Student Fee Payment' portal. Where you can not only add, update and remove the students but also record payments against those students.
## Features
### Entities
#### 1. Student
- View Student record list
- View Student record details
- Add Student record
- Update a Student record
- Delete a Student Record

#### 2. Fee Payment
- View Fee Payment record list
- View Fee Payment record details
- Add Fee Payment record
- Update a Fee Payment record

## Technologies
#### FrontEnd:
- Angular 16
#### BackEnd:
- .Net Core Web API
- EF Core
#### Database:
- MSSQL

## Repo Structure
- [backend](https://github.com/jahanzab/StudentFeePayment/tree/main/backend/StudentFeePayment) directory contains the back end project
- [frontend](https://github.com/jahanzab/StudentFeePayment/tree/main/frontend/student-fee-payment) directory contains the frontend project


## Installation

#### Backend:
1. Run the sql [script](https://github.com/jahanzab/StudentFeePayment/blob/main/fee-payment.sql) in your MSSQL instance
2. Run the backend project using Visual Studio
3. Note down the url API is running at (probably will be running at `https://localhost:7068`)
4. Also please make sure that connection string in `appsettings.Development.json` file points to your local SQL server instance

```javascript
   "ConnectionStrings": {
    "ConnectionString": "Server=localhost;Database=SchoolDB;TrustServerCertificate=True;Trusted_Connection=True"
  }
```

#### FrontEnd:
1. Open the project in your editor
2. Run the `npm i` command to install the dependencies
3. Paste the above noted API url in [environment](https://github.com/jahanzab/StudentFeePayment/tree/main/frontend/student-fee-payment/src/environments) files

```javascript
 apiBaseUrl: '[API_URL]/api'
```
4. Run the project using command
```javascript
 ng serve --open
```

## Views

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/home.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/student-list.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/student-new.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/student-edit.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/feepayment-list.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/feepayment-new.png?raw=true)

>![](https://github.com/jahanzab/StudentFeePayment/blob/main/images/feepayment-details.png?raw=true)

## License

[MIT](https://choosealicense.com/licenses/mit/)
