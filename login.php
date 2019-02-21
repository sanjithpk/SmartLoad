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
 
$use=$_POST["user_name"];;
$pwd=$_POST["password"];;


  $sql="select * from login1 where username='".$use."' AND password='".$pwd."'";
 $result=mysqli_query($conn,$sql) or die(mysql_error($conn));
  $rows=mysqli_num_rows($result);
  
  if($rows==1){
 	session_start();
 	$_SESSION['login']=true;
 	echo "login success";
 } else{
 	echo"You have entered incorrect username/password";
 	}
 $conn->close();
session_unset();
session_destroy();
?>