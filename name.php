<?php

$servername='localhost';
$username='root';
$password='';
$dbname='sload';
$con=new mysqli($servername,$username,$password,$dbname);
if ($con->connect_error) {
	die("Failed".$con->connect_error);
}
$query=mysqli_query($con,"SELECT * FROM name");

if($query)
{
    while($row=mysqli_fetch_array($query))
    {
        $flag[]=$row;
    }

    print(json_encode($flag));
}
mysqli_close($con);
?>