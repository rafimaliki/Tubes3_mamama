import os
import mysql.connector

list_nama = []
list_path = []
relative_path = "../../../../../../data/"

# Function to connect to the database and print table data
def get_nama():
    try:
        # Connect to the database
        mydb = mysql.connector.connect(
            host="localhost",
            user="root",
            password="password",
            database="tubes3"
        )

        # Create cursor
        mycursor = mydb.cursor()

        # Execute query to print table biodata
        mycursor.execute("SELECT nama FROM biodata")
        myresult = mycursor.fetchall()
        for x in myresult:
            list_nama.append(x[0])


    except mysql.connector.Error as err:
        print(f"Error: {err}")
        
    finally:
        if mydb.is_connected():
            mycursor.close()
            mydb.close()

# Function to print all file paths in the given directory
def get_path(path):
    if not os.path.exists(path):
        print(f"The directory '{path}' does not exist.")
        return

    for root, dirs, files in os.walk(path):
        for file in files:
            file_path = os.path.join(root, file)
            file_path = file_path.replace("\\", "/")
            # index_of__ = file_path.find("_")
            # # number = file_path[13:index_of__]
            
            list_path.append(relative_path+file_path)

# query to insert value to table fingerprint
def insert_fingerprint(nama, path):
    try:
        # Connect to the database
        mydb = mysql.connector.connect(
            host="localhost",
            user="root",
            password="password",
            database="tubes3alay"
        )
        
        # Create cursor
        mycursor = mydb.cursor()
        
        # Execute query to insert value to table fingerprint
        sql = "INSERT INTO sidik_jari (berkas_citra, nama) VALUES (%s, %s)"
        val = (path, nama)
        mycursor.execute(sql, val)
    
        # Commit the changes
        mydb.commit()
        print(mycursor.rowcount, "record inserted.")
    
    except mysql.connector.Error as err:
        print(f"Error: {err}")

class sidik_jari:
    def __init__(self, path, nama):
        self.path = path
        self.nama = nama
    
    
        
def add_relative_path():
    
    # get all sidik jari and put to class sidik jari
    try:
        # Connect to the database
        mydb = mysql.connector.connect(
            host="localhost",
            user="root",
            password="password",
            database="tubes3"
        )
        
        # Create cursor
        mycursor = mydb.cursor()
        
        # Execute query to insert value to table fingerprint
        sql = "SELECT * FROM sidik_jari"
        mycursor.execute(sql)
        myresult = mycursor.fetchall()
        
        list_sidik_jari = []
        for x in myresult:
            list_sidik_jari.append(sidik_jari(relative_path+x[0], x[1]))
            
        # delete all data from tble sidik jari
        sql = "DELETE FROM sidik_jari"
        mycursor.execute(sql)
        mydb.commit()
        
        # insert all data to table sidik jari
        for sidik_jari in list_sidik_jari:
            insert_fingerprint(sidik_jari.nama, sidik_jari.path)
        
    except mysql.connector.Error as err:
        print(f"Error: {err}")
        
            
if __name__ == "__main__":
    get_nama()
    get_path("fingerprints")
    
    for i in range(len(list_nama)):
        for j in range (i*10, i*10+10):
            insert_fingerprint(list_nama[i], list_path[j])
    