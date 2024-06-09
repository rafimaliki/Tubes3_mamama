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
* [How To Run](#how-to-run:)
* [Project Status](#project-status)
* [Acknowledgements](#acknowledgements)
* [Contact](#contact)



## About The Project
<p align = "center"> This application implements a biometric identification system using fingerprint recognition. The system utilizes the Boyer-Moore and Knuth-Morris-Pratt algorithms for fingerprint detection and matching. Additionally, the system is integrated with a database containing individual identities, enabling the complete identification of a person using only their fingerprint. This project aims to create a robust and efficient fingerprint recognition system that links biometric data with personal identity information, ensuring accurate and reliable individual identification. </p>


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
![Example screenshot](/img/homepage.png)

### Solver Page
![Example screenshot](/img/solverpage.png)

### About Us Page
![Example screenshot](/img/aboutus.png)

## How To Run:

### Create MYSQL Database

1. cd data
2. open mysql
3. create database tubes3
4. source data.sql
5. exit

### Run Program

1. open terminal as administrator
2. set working directory to project root (Tubes3_mamama/)
3. set DB_PASSWORD={your_mysql_password}
4. run batch file (type ./run.bat)


## Project Status
Project is: _completed_


## Acknowledgements
- This project was made as a Algorithm Strategy course assignment at Institut Teknologi Bandung


## Contact
Created by : 
- [Maulvi Ziadinda Maulana - 13522122](https://github.com/maulvi-zm) 
- [Shabrina Maharani - 13522134](https://github.com/Maharanish)
- [Ahmad Rafi Maliki - 13522137](https://github.com/rafimaliki)


