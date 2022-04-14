# AutomapperTestProject

Current Problem:

<pre><code>AutoMapper.AutoMapperConfigurationException : The following member on AutomapperTestProject.Models.ProjectSpecificFactorModel cannot be mapped: 
	DiscountFactor 
Add a custom mapping expression, ignore, add a custom resolver, or modify the destination type AutomapperTestProject.Models.ProjectSpecificFactorModel.
Context:
	Mapping to member DiscountFactor from AutomapperTestProject.Entities.ProjectSpecificFactor to AutomapperTestProject.Models.ProjectSpecificFactorModel
Exception of type 'AutoMapper.AutoMapperConfigurationException' was thrown.

  Stack Trace: 
ConfigurationValidator.AssertConfigurationIsValid(IEnumerable`1 typeMaps)
ConfigurationValidator.AssertConfigurationExpressionIsValid(IEnumerable`1 typeMaps)
MapperConfiguration.AssertConfigurationIsValid()
AutoMapperTest.Ensure_Configs_Valid() line 28</code></pre>
