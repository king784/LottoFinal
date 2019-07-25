 <?php
$servername = "localhost";
$username = "id10269157_arpaadmin";
$password = "SALAsana19";
$dbname = "id10269157_arvontaesineet";

$raffleName = $_POST["raffleName"];
$totalTickets = $_POST["totalTickets"];
$winningChance = $_POST["winningChance"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "UPDATE RaffleSettings SET RaffleName = '".$raffleName."', TotalTickets = '".$totalTickets."', WinningChance = '".$winningChance."'";
$result = $conn->query($sql);

$conn->close();
?> 