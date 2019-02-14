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

// To check whether analytics table responds
$target_dir = "uploads/";
$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
$uploadOk = 1;
$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
// Check if image file is a actual image or fake image
if(isset($_POST["submit"])) {
    $check = getimagesize($_FILES["fileToUpload"]["tmp_name"]);
    if($check !== false) {
        $uploadOk = 1;
    } else {
        echo "File is not an image.";
        $uploadOk = 0;
    }
}
if ($uploadOk == 0) {
    echo "Sorry, image was not uploaded.";
// if everything is ok, try to upload file
}  else {
    if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {
    	
    	 $time=date("Y-m-d H:i:s");//timestamp
        $file=$_FILES['fileToUpload']['name'];//Name of file
        
       $sql = "INSERT INTO  analytics(datet, directory)
	VALUES ('$time', '$file')";

	if (mysqli_query($conn,$sql)) {
	    $last_id = mysqli_insert_id($conn);
	   	 echo "New record created successfully. Last inserted ID is: " . $last_id;
	} 
	else 
	    echo "Error: " . $sql . "<br>" . $conn->error;

    } else {
        echo "Sorry, there was an error uploading your file.";
    }
}
$conn->close();
?>