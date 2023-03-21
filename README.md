<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1154690)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid for Blazor - How to implement custom validation

This example demonstrates how to create a custom validator component and use it to validate data in the [Devexpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/grid). In the example, the `MyCustomValidator` component checks the **Title** field value and displays an error message if the value does not contain the **Sales** word.

![Implement Custom Validation in the Grid](/images/custom-validation.png)

## Overview

Follow the steps below to implement custom validation in a Grid component:

1. Add a [Grid](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid) component to a page and bind the component to data.
2. Enable editing operations in the Grid as described in the following topic: [Edit Data and Validate Input](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input).
3. Create a custom [validator component](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-and-input-components?view=aspnetcore-7.0#validator-components) on a separate page. In the component, create a storage for error messages and implement methods that add and display errors and clear the storage. Create a `DataItemValidating` event and invoke it when the [edit context](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext?view=aspnetcore-7.0) requests validation ([OnValidationRequested](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.onvalidationrequested?view=aspnetcore-7.0)) and the context's field value changes ([OnFieldChanged](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.onfieldchanged?view=aspnetcore-7.0)).
4. Declare the validator component in the Grid's [CustomValidators](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.CustomValidators) template and handle the `DataItemValidating` event. In the event handler, validate edit model values and display error messages, if any.

## Files to Review

- [Index.razor](./CS/Pages/Index.razor)
- [CustomValidator.cs](./CS/Pages/CustomValidator.cs)

## Documentation

- [Bind to Data](https://docs.devexpress.com/Blazor/403737/grid/bind-to-data)
- [Examples](https://docs.devexpress.com/Blazor/404035/grid/examples)

## More Examples

- [Grid for Blazor - Bind the component to data with Entity Framework Core](https://github.com/DevExpress-Examples/blazor-dxgrid-bind-to-data-with-entity-framework-core)
- [Grid for Blazor - Restrict data editing to rows that match specific conditions](https://github.com/DevExpress-Examples/blazor-dxgrid-disable-editing-for-several-rows)
- [Grid for Blazor - Create an edit form and modify grid data on a separate page](https://github.com/DevExpress-Examples/blazor-DxGrid-Separate-Edit-Form)
