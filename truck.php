<?php
session_start();
$servername='localhost';
$username='root';
$password='';
$dbname='sload';
$con=new mysqli($servername,$username,$password,$dbname);
if ($con->connect_error) {
	die("Failed".$con->connect_error);
}
 
// $use=$_POST["user_name"];;
// $pwd=$_POST["password"];;


  $sql="SELECT * FROM truck";
  $result = mysqli_query($con, $sql);
  if($result) {
    while($row = mysqli_fetch_array($result)) {
      $flag[] = $row;
    }

    print(json_encode($flag));
  }
  mysqli_close($con);
?>