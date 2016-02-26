# _Hair Salon_

#### _C# database basics code review, 2/26/2016_

#### By _**David Diehr**_

## Description

This is a very simple web app that would allow the owner or manager of a
a theoretical hair salon to maintain and edit a database that keeps track of their
stylists and clients.

## Setup/Installation Requirements

* _Clone this repository_
* _Open the Windows Powershell and connect to your local database_
* _In SQLCMD:_
* _1>CREATE DATABASE hair\_salon;_
* _2>GO_
* _1>USE hair\_salon;_
* _2>GO_
* _1>CREATE TABLE stylist (id INT IDENTITY(1,1), name VARCHAR(255));_
* _2>CREATE TABLE client (id INT IDENTITY(1,1), name VARCHAR(255), stylist_id INT);_
* _3>GO_
* _1>Quit_
* _In the Windows Powershell navigate to the project folder_
* _and run the following commands:_
* _dnu restore_
* _dnx kestrel_
* _Then open the browser of your choice to localhost:5004_


## Known Bugs

_None._


## Technologies Used

_C# with the Nancy web framework; SQL Server 2016 CTP3; HTML; xUnit for testing_

### Legal

Copyright (c) 2016 **_David Diehr_**

This software is licensed under the MIT license.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
