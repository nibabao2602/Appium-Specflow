@loginTest
Feature: LoginTest
	
        @test123
        Scenario: Login
            Given Navigate to Login page
             Then Enter jobseeker04@yopmail.com and P@ssw0rd
              And Click on Login button
              And Wait 10000
              And Dismiss Notifications After Login
            #  When Homepage is displayed
             Then Go to First Job
              And Click on Apply Now
              And Upload file
             When Verify file is attached successfully
             Then Enter job title "abcfđsal"
              And Click on confirm apply
              And Verify successful apply
        
        # @test123
        # Scenario: SignUp
        #     Given Navigate to Login page
        #      Then Enter jobseeker04@yopmail.com and P@ssw0rd
        #       And Click on Login button
        #       And Wait 10000
        #       And Dismiss Notifications After Login
        #      When Homepage is displayed