<?php
session_start();
$servername='localhost';
$username='root';
$password='';
$dbname='sload';
$conn=new mysqli($servername,$username,$password,$dbname);
if ($conn->connect_error) {
	die("Failed".$conn->connect_error);
}
 
// $use=$_POST["user_name"];;
// $pwd=$_POST["password"];;


  $sql="INSERT INTO tyre (diameter, width, weight)
  VALUES ('3', '1', '2')";  
  
  if ($conn->query($sql) === TRUE) {
    echo "New record created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}
 $conn->close();
?>