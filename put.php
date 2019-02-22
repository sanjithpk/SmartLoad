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

//fetch info
$sql="SELECT * FROM analytics";
 $result=$conn->query($sql);
if($result){
	if($result->num_rows==1){
		$row=mysqli_fetch_assoc($result);
	//print headers
	header("Content-type: image/png");
	// header("Content-Disposition: attachment; filname=".$row['file']);
	//print data
	echo $row['image'];
	}
}
// if($result = mysqli_query($conn,$sql)){
// 	 // We have results, create an array to hold the results
//         // and an array to hold the data
//  $resultArray = array();
//  $tempArray = array();
 
//  // Loop through each result
//  while($row = $result->fetch_object())
//  {
//  // Add each result into the results array
//  $tempArray = $row;
//      array_push($resultArray, $tempArray);
//  }
 
//  // Encode the array to JSON and output the results
//  echo json_encode($resultArray);
// }

else
	{
		echo "Failed";
	}
$conn->close();
session_unset();
session_destroy(); 
 ?>
