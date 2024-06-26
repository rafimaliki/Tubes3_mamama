# Tubes3_mamama

<br />
<div align="center">

<h3 align="center">
IF2211 Strategi Algoritma</h3>

  <p align="center">
    Tugas Besar 3: Pemanfaatan Pattern Matching dalam Membangun Sistem Deteksi Individu Berbasis Biometrik Melalui Citra Sidik Jari
    <br />
    <a href="https://github.com/rafimaliki/Tubes3_mamama"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/rafimaliki/Tubes3_mamama">View Demo</a>
    ·
    <a href="https://github.com/rafimaliki/Tubes3_mamama/issues">Report Bug</a>
    ·
    <a href="https://github.com/rafimaliki/Tubes3_mamama/issues">Request Feature</a>
  </p>
</div>

## Table of Contents
* [General Info](#about-the-project)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [How To Run](#how-to-run)
* [Project Status](#project-status)
* [Acknowledgements](#acknowledgements)
* [Contact](#contact)



## About The Project
<p align = "center"> This application implements a biometric identification system using fingerprint recognition. The system utilizes the Boyer-Moore and Knuth-Morris-Pratt algorithms for fingerprint detection and matching. The Knuth-Morris-Pratt (KMP) algorithm is an efficient pattern matching algorithm that preprocesses the pattern to create a partial match table, allowing the search to skip sections of the text, thus improving search performance. The Boyer-Moore (BM) algorithm is another efficient pattern matching algorithm that preprocesses the pattern to create two heuristics, the bad character rule and the good suffix rule, which help in skipping sections of the text during the search process, making it faster, especially with larger patterns. Additionally, regular expressions are used to handle corrupted name data, ensuring that even with inconsistencies or variations in the name entries, the system can still perform accurate matches. The system is integrated with a database containing individual identities, enabling the complete identification of a person using only their fingerprint. This project aims to create a robust and efficient fingerprint recognition system that links biometric data with personal identity information, ensuring accurate and reliable individual identification. </p>


## Technologies Used
- .NET 8.0 SDK (include C#) : The main framework used for building and running the application.
- Avalonia v11.1.0 : A cross-platform UI framework used for building the application's user interface.
- MariaDB v11.3 : The database system used to store biometric data and user information
  

## Features

- [x] Home Page : Displays a welcome message and our program description
- [x] Solver Page : Allows users to upload fingerprint images and select the desired algorithm (KMP or Boyer-Moore) for biometric identification.
- [x] KMP algorithm :  Implements the Knuth-Morris-Pratt algorithm to efficiently search for fingerprint patterns within the uploaded image.
- [x] Boyer Moore Algorithm : Utilizes the Boyer-Moore string matching algorithm to find and identify fingerprint patterns in the provided image.
- [x] About Us : Provides information the development team

## Screenshots
### Home Page
![Example screenshot](/doc/homepage.png)

### Solver Page
![Example screenshot](/doc/solverpage.png)

### About Us Page
![Example screenshot](/doc/aboutus.png)

## How To Run

### Create MYSQL Database (First time only)

change working directory to data/
```sh
cd Tubes3_mamama/data
```
open mysql
```sh
mysql -u root -p
```
create new database named tubes3
```sh
create database tubes3
```
use the database
```sh
use tubes3
```
source dumped data
```sh
source data.sql
```
exit

### Run Program
open terminal as administrator
set working directory to project root (Tubes3_mamama/)
```sh
cd Tubes3_mamama/
```
set DB_PASSWORD environment variable
```sh
set DB_PASSWORD={your_mysql_password}
```
run batch file
```sh
# for Windows
run.bat

# for MacOS
run.sh
```


## Project Status
Project is: _completed_


## Acknowledgements
- This project was made as a Algorithm Strategy course assignment at Institut Teknologi Bandung


## Contact
Created by : 
- [Maulvi Ziadinda Maulana - 13522122](https://github.com/maulvi-zm) 
- [Shabrina Maharani - 13522134](https://github.com/Maharanish)
- [Ahmad Rafi Maliki - 13522137](https://github.com/rafimaliki)


