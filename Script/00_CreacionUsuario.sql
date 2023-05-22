ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;

CREATE USER metricatest IDENTIFIED BY "abcd1234" default tablespace users quota unlimited on users;

GRANT CONNECT, RESOURCE TO metricatest;
