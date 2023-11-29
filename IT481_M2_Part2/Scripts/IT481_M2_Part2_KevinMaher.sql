Use Northwind;

-- Create roles/groups for security in the database
CREATE ROLE SalesRole;
CREATE ROLE HRRole;
CREATE ROLE CEORole;

-- Modify access for those roles/groups
-- Grant SalesRole the ability to view Orders and Customers table
GRANT SELECT ON Orders TO SalesRole;
GRANT SELECT ON Customers TO SalesRole;

-- Grant HRRole the ability to view Employee table
GRANT SELECT ON Employees TO HRRole;

-- Grant CEORole the ability to view Orders, Customers, and Employee tables
GRANT SELECT ON Orders TO CEORole;
GRANT SELECT ON Customers TO CEORole;
GRANT SELECT ON Employees TO CEORole;

-- Create three new database users

CREATE USER User_CEO WITH PASSWORD ='1Password!';
CREATE USER User_HR WITH PASSWORD = '2Password!';
CREATE USER User_Sales WITH PASSWORD = '3Password!';


-- Add each user to the appropriate role/group
ALTER ROLE SalesRole ADD MEMBER User_Sales;
ALTER ROLE HRRole ADD MEMBER User_HR;
ALTER ROLE CEORole ADD MEMBER User_CEO;


