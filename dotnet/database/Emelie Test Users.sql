SELECT * FROM users;
SELECT * FROM addresses;

UPDATE users SET app_status = 'pending' WHERE user_id = 1;
UPDATE users SET app_status = 'pending' WHERE user_id = 2;
UPDATE users SET app_status = 'pending' WHERE user_id = 3;
UPDATE users SET app_status = 'pending' WHERE user_id = 4;
SELECT * FROM users;
SELECT * FROM addresses;

UPDATE users SET user_role = 'friend' WHERE user_id = 1;
UPDATE users SET user_role = 'friend' WHERE user_id = 2;
UPDATE users SET user_role = 'admin' WHERE user_id = 3;
UPDATE users SET user_role = 'admin' WHERE user_id = 4;
SELECT * FROM users;
SELECT * FROM addresses;