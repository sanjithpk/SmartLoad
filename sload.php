<?php  
$servername="localhost";
$Username="root";
$Password="";
$dbname="sload";

//Create a connection to database
	$conn=mysqli_connect($servername,$Username,$Password,$dbname);
	// Check connection
	if (!$conn) {
	    die("Connection failed: " . mysqli_connect_error());
	}

//To check whether login table responds

	$sql = "INSERT INTO  login(Username, Password)
	VALUES ('John', 'Doe')";

	if (mysqli_query($conn,$sql)) {
	    $last_id = mysqli_insert_id($conn);
	   	 echo "New record created successfully. Last inserted ID is: " . $last_id;
	} 
	else 
	    echo "Error: " . $sql . "<br>" . $conn->error;
	
$conn->close();
?>