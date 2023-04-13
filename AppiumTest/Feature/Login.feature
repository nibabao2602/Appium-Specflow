@loginTest
Feature: LoginTest
	
        @test123
        Scenario: Login
            Given Navigate to Login page
             Then Enter jobseeker04@yopmail.com and P@ssw0rd
              And Click on Login button
              And Wait 10000
              And Dismiss Notifications After Login
             When Homepage is displayed
        
        # @test123
        # Scenario: SignUp
        #     Given Navigate to Login page
        #      Then Enter jobseeker04@yopmail.com and P@ssw0rd
        #       And Click on Login button
        #       And Wait 10000
        #       And Dismiss Notifications After Login
        #      When Homepage is displayed