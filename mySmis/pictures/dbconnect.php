<?php
error_reporting( E_ALL & ~E_DEPRECATED & ~E_NOTICE );
if(!mysql_connect("MYSQL5011.Smarterasp.net","9e411d_qrafiqx","secretw0rd"))
{
	die('oops connection problem ! --> '.mysql_error());
}
if(!mysql_select_db("db_9e411d_qrafiqx"))
{
	die('oops database selection problem ! --> '.mysql_error());
}

?>