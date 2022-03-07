Feature: Login
Login page verification

    Scenario: A user cannot login with empty username and password
        Given user visits the login page
        When user logs in with credentials
          | username | password |
          |          |          |
        Then the login error Please enter a username and password. is displayed

    Scenario: A user cannot login with empty username
        Given user visits the login page
        When user logs in with credentials
          | username | password |
          |          | user     |
        Then the login error Please enter a username and password. is displayed

    Scenario: A user cannot login with empty password
        Given user visits the login page
        When user logs in with credentials
          | username | password |
          | user     |          |
        Then the login error Please enter a username and password. is displayed

    Scenario: A user can login with valid username and password
        Given user visits the login page
        When user logs in with credentials
          | username | password |
          | user     | user     |
        Then user is logged in successfully
