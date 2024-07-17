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
namespace Mc2.CrudTest.Api.Integration.Test.Tests.Customer.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class CreateCustomerCommandFeature : object, Xunit.IClassFixture<CreateCustomerCommandFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "CreateCustomerCommand.feature"
#line hidden
        
        public CreateCustomerCommandFeature(CreateCustomerCommandFeature.FixtureData fixtureData, Mc2_CrudTest_Api_Integration_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Tests/Customer/Features", "CreateCustomerCommand", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [Xunit.SkippableFactAttribute(DisplayName="Create Customer with POST Request.Then http status should be OK")]
        [Xunit.TraitAttribute("FeatureTitle", "CreateCustomerCommand")]
        [Xunit.TraitAttribute("Description", "Create Customer with POST Request.Then http status should be OK")]
        public virtual void CreateCustomerWithPOSTRequest_ThenHttpStatusShouldBeOK()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Customer with POST Request.Then http status should be OK", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
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
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber",
                            "CreatedDate"});
                table1.AddRow(new string[] {
                            "22222222-2222-2222-2222-222222222222",
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 60",
                            "fuat@fuat.com",
                            "2234567890",
                            "CURRENT_DATETIME"});
                table1.AddRow(new string[] {
                            "33333333-3333-3333-3333-333333333333",
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "yildirim@yildirim.com",
                            "3234567890",
                            "CURRENT_DATETIME"});
#line 4
        testRunner.Given("Customers are", ((string)(null)), table1, "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table2.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "ali@ali.com",
                            "1234567890"});
#line 8
        testRunner.When("POST \"/customer/create\" is called with parameters", ((string)(null)), table2, "When ");
#line hidden
#line 11
        testRunner.Then("Http status code should be 200 and Message should be \"\" and error code should be " +
                        "\"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "DateOfBirth",
                            "PhoneNumber",
                            "Email",
                            "BankAccountNumber"});
                table3.AddRow(new string[] {
                            "Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-12d",
                            "+90 532 123 45 60",
                            "fuat@fuat.com",
                            "2234567890"});
                table3.AddRow(new string[] {
                            "Ali Fuat",
                            "YILDIRIM",
                            "DATE_ONLY-11d",
                            "+90 532 123 45 61",
                            "yildirim@yildirim.com",
                            "3234567890"});
                table3.AddRow(new string[] {
                            "Ali",
                            "YILDIRIM",
                            "DATE_ONLY-10d",
                            "+90 532 123 45 62",
                            "ali@ali.com",
                            "1234567890"});
#line 12
        testRunner.Then("Customers should be", ((string)(null)), table3, "Then ");
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
                CreateCustomerCommandFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                CreateCustomerCommandFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
