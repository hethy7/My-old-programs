<?php
//Adatbázishoz
$DB_connection = false;
 
function DB_error($critical){
    if ($critical){
        $message = mysqli_connect_errno()." : ".mysqli_connect_error()."<br />";
        print $message;
        exit();
    }
    else{
        $message = mysqli_errno($GLOBALS["DB_connection"])." : ".
            mysqli_error($GLOBALS["DB_connection"])."<br />";
        return $message;
    }
}
 
function DB_query($sql){
    $result = mysqli_query($GLOBALS["DB_connection"], $sql);
    if (!$result){
        print DB_error(false);
        print "Lekérdezés:<br />".$sql;
    }
    return $result;
}
 
function DB_connect($host, $user, $pass, $db, $charset){
    $GLOBALS["DB_connection"] = mysqli_connect($host, $user, $pass, $db);
    if (!$GLOBALS["DB_connection"]){
        print DB_error(true);
    }
    DB_query("SET NAMES '$charset'");
    return $GLOBALS["DB_connection"];
}
 
function DB_close(){
    return mysqli_close($GLOBALS["DB_connection"]);
}
 
function DB_fetch_assoc($result){
    if (is_object($result)){
        return mysqli_fetch_assoc($result);
    }
    else{
        print 'DB_fetch_assoc : hibás argumentum!<br />';
        return false;
    }
}
 
function DB_getrows($sql){
    $result = DB_query($sql);
    $table = array();
    while ($row = DB_fetch_assoc($result)){
        $table[] = $row;
    }
    return $table;
}
 
function DB_getrow($sql, $rownum = 0){
    $rows = DB_getrows($sql);
    if (count($rows) > $rownum){
        return $rows[$rownum];
    }
    else{
        return false;
    }
}
 
function DB_getcolumns($sql){
    $rows = DB_getrows($sql);
    $cols = array();
    foreach ($rows as $i => $row){
        foreach ($row as $colname => $value){
            $cols[$colname][$i] = $value;
        }
    }
    return $cols;
}
 
function DB_getcolumn($sql, $colname){
    $cols = DB_getcolumns($sql);
    if (isset($cols[$colname])){
        return $cols[$colname];
    }
    else{
        return false;
    }
}
 
function DB_getfield($sql, $colname, $rownum = 0){
    $rows = DB_getrows($sql);
	if (isset($rows[$rownum][$colname])){
        return $rows[$rownum][$colname];
    }
    else{
        return false;
    }
}
 
function DB_num_rows($result){
    return mysqli_num_rows($result);
}
 
function DB_affected_rows(){
    return mysqli_affected_rows($GLOBALS["DB_connection"]);
}
 
function DB_insert_id(){
    return mysqli_insert_id($GLOBALS["DB_connection"]);
}
 
function DB_next_id($table){
    $id = DB_getfield("SHOW TABLE STATUS LIKE '$table'", "Auto_increment");
    return $id;
}

?>