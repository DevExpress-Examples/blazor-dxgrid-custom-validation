<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1154690)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid for Blazor - How to implement custom validation

This example demonstrates how to create a custom validator component and use it to validate the [Devexpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/grid). In the example, the **MyCustomValidator** component checks the **Title** field value and displays an error message if the value does not contain the **Sales** word.

![Implement Custom Validation in the Grid](/images/custom-validation.png)

## Overview

Follow the steps below to implement custom validation in the Grid component:

1. Create a [Grid](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid) component and bind it to data.
2. Enable editing in the Grid. Refer to the following topic for more information on how to allow users to add, edit, and delete data rows: [Edit Data and Validate Input](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input).
3. Create a custom validator components as described in the following Microsoft topic: [Validator components](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-and-input-components?view=aspnetcore-7.0#validator-components).
4. Declare the validator component in the Grid's [CustomValidators](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.CustomValidators) template to enable custom validation.
5. The [EditModelSaving](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditModelSaving) event occurs when a user submits the edit form or saves changes in the edit row. Use the [EditModel](https://docs.devexpress.com/Blazor/DevExpress.Blazor.GridEditModelSavingEventArgs.EditModel) event argument to access an edit model that stores all changes. Validate edit model values and use the validator component to display error messages, if any.

## Files to Review

- [Index.razor](./CS/Pages/Index.razor)
- [CustomValidator.cs](./CS/Pages/CustomValidator.cs)

## Documentation

- [Bind to Data](https://docs.devexpress.com/Blazor/403737/grid/bind-to-data)
- [Examples](https://docs.devexpress.com/Blazor/404035/grid/examples)

## More Examples

- [Grid for Blazor - How to bind the component to data with Entity Framework Core](https://github.com/DevExpress-Examples/blazor-dxgrid-bind-to-data-with-entity-framework-core)
- [Grid for Blazor - Restrict data editing to rows that match specific conditions](https://github.com/DevExpress-Examples/blazor-dxgrid-disable-editing-for-several-rows)
- [Grid for Blazor - Create an edit form and modify grid data on a separate page](https://github.com/DevExpress-Examples/blazor-DxGrid-Separate-Edit-Form)
