﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestCase.Api.Integration.Test.Tests.User.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreateCustomerCommand_ValidationFeature : object, Xunit.IClassFixture<CreateCustomerCommand_ValidationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreateCustomerCommand.Validation.feature"
#line hidden
        
        public CreateCustomerCommand_ValidationFeature(CreateCustomerCommand_ValidationFeature.FixtureData fixtureData, TestCase_Api_Integration_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Tests/User/Features", "CreateCustomerCommand.Validation", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Customer exist firstname,lastname,dateofbirth with POST Request.Error code" +
            " should be \"E1004\"")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateCustomerCommand.Validation")]
        [Xunit.TraitAttribute("Description", "Create Customer exist firstname,lastname,dateofbirth with POST Request.Error code" +
            " should be \"E1004\"")]
        public virtual void CreateCustomerExistFirstnameLastnameDateofbirthWithPOSTRequest_ErrorCodeShouldBeE1004()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Customer exist firstname,lastname,dateofbirth with POST Request.Error code" +
                    " should be \"E1004\"", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber",
                            "CreatedDate"});
                table4.AddRow(new string[] {
                            "11111111-1111-1111-1111-111111111111",
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 60",
                            "ali@ali.com",
                            "1234567890",
                            "CURRENT_DATETIME"});
                table4.AddRow(new string[] {
                            "22222222-2222-2222-2222-222222222222",
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "fuat@fuat.com",
                            "2234567890",
                            "CURRENT_DATETIME"});
                table4.AddRow(new string[] {
                            "33333333-3333-3333-3333-333333333333",
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "yildirim@yildirim.com",
                            "3234567890",
                            "CURRENT_DATETIME"});
#line 4
        testRunner.Given("Customers are", ((string)(null)), table4, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table5.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 63",
                            "alifuat@alifuat.com",
                            "1234567890"});
#line 9
        testRunner.When("POST \"/customer/create\" is called with parameters", ((string)(null)), table5, "When ");
#line hidden
#line 12
        testRunner.Then("Http status code should be 409 and Message should be \"This person has already reg" +
                        "istered.\" and error code should be \"E1004\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Customer exist email with POST Request.Error code should be \"E1003\"")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateCustomerCommand.Validation")]
        [Xunit.TraitAttribute("Description", "Create Customer exist email with POST Request.Error code should be \"E1003\"")]
        public virtual void CreateCustomerExistEmailWithPOSTRequest_ErrorCodeShouldBeE1003()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Customer exist email with POST Request.Error code should be \"E1003\"", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 14
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber",
                            "CreatedDate"});
                table6.AddRow(new string[] {
                            "22222222-2222-2222-2222-222222222222",
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "fuat@fuat.com",
                            "2234567890",
                            "CURRENT_DATETIME"});
                table6.AddRow(new string[] {
                            "33333333-3333-3333-3333-333333333333",
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "yildirim@yildirim.com",
                            "3234567890",
                            "CURRENT_DATETIME"});
#line 15
        testRunner.Given("Customers are", ((string)(null)), table6, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table7.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 63",
                            "fuat@fuat.com",
                            "1234567890"});
#line 19
        testRunner.When("POST \"/customer/create\" is called with parameters", ((string)(null)), table7, "When ");
#line hidden
#line 22
        testRunner.Then("Http status code should be 409 and Message should be \"This email has been used be" +
                        "fore.\" and error code should be \"E1003\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Customer wrong phone number with POST Request.Error code should be \"E1001\"" +
            "")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateCustomerCommand.Validation")]
        [Xunit.TraitAttribute("Description", "Create Customer wrong phone number with POST Request.Error code should be \"E1001\"" +
            "")]
        public virtual void CreateCustomerWrongPhoneNumberWithPOSTRequest_ErrorCodeShouldBeE1001()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Customer wrong phone number with POST Request.Error code should be \"E1001\"" +
                    "", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 24
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber",
                            "CreatedDate"});
                table8.AddRow(new string[] {
                            "22222222-2222-2222-2222-222222222222",
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "fuat@fuat.com",
                            "2234567890",
                            "CURRENT_DATETIME"});
                table8.AddRow(new string[] {
                            "33333333-3333-3333-3333-333333333333",
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "yildirim@yildirim.com",
                            "3234567890",
                            "CURRENT_DATETIME"});
#line 25
        testRunner.Given("Customers are", ((string)(null)), table8, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table9.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "asdasd",
                            "ali@ali.com",
                            "1234567890"});
#line 29
        testRunner.When("POST \"/customer/create\" is called with parameters", ((string)(null)), table9, "When ");
#line hidden
#line 32
        testRunner.Then("Http status code should be 400 and Message should be \"Invalid phone number.\" and " +
                        "error code should be \"E1001\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Customer wrong bank account with POST Request.Error code should be \"E1001\"" +
            "")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateCustomerCommand.Validation")]
        [Xunit.TraitAttribute("Description", "Create Customer wrong bank account with POST Request.Error code should be \"E1001\"" +
            "")]
        public virtual void CreateCustomerWrongBankAccountWithPOSTRequest_ErrorCodeShouldBeE1001()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Customer wrong bank account with POST Request.Error code should be \"E1001\"" +
                    "", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 34
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber",
                            "CreatedDate"});
                table10.AddRow(new string[] {
                            "22222222-2222-2222-2222-222222222222",
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "fuat@fuat.com",
                            "2234567890",
                            "CURRENT_DATETIME"});
                table10.AddRow(new string[] {
                            "33333333-3333-3333-3333-333333333333",
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "yildirim@yildirim.com",
                            "3234567890",
                            "CURRENT_DATETIME"});
#line 35
        testRunner.Given("Customers are", ((string)(null)), table10, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table11.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 63",
                            "ali@ali.com",
                            "asdasdsad"});
#line 39
        testRunner.When("POST \"/customer/create\" is called with parameters", ((string)(null)), table11, "When ");
#line hidden
#line 42
        testRunner.Then("Http status code should be 400 and Message should be \"Invalid bank account number" +
                        ".\" and error code should be \"E1001\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                CreateCustomerCommand_ValidationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateCustomerCommand_ValidationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
