 <?php
$servername = "localhost";
$username = "id10269157_arpaadmin";
$password = "SALAsana19";
$dbname = "id10269157_arvontaesineet";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}


$sql = "SELECT * FROM Prizes";
$result = $conn->query($sql);


if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "ItemID:" . $row["ItemID"]. "|ItemName:" . $row["ItemName"]. "|Description:" . $row["Description"]. ";";
    }
} else {
    echo "0 results";
}

$conn->close();
?> 