UPDATE users SET app_status = 'rejected' WHERE user_id = 1;
UPDATE users SET app_status = 'pending' WHERE user_id = 2;
UPDATE users SET app_status = 'approved' WHERE user_id = 3;
UPDATE users SET app_status = 'approved' WHERE user_id = 4;
SELECT * FROM users;
SELECT * FROM addresses;

UPDATE users SET user_role = 'friend' WHERE user_id = 1;
UPDATE users SET user_role = 'friend' WHERE user_id = 2;
UPDATE users SET user_role = 'friend' WHERE user_id = 3;
UPDATE users SET user_role = 'friend' WHERE user_id = 4;
SELECT * FROM users;
SELECT * FROM addresses;

UPDATE users SET is_not_active = 1 WHERE user_id = 4;
SELECT * FROM users;
SELECT * FROM addresses;