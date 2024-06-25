<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/616447972/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1154690)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Grid for Blazor - How to implement custom validation

This example demonstrates how to create a custom validator component and use it to validate [DevExpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/grid) data. In the example, the `MyCustomValidator` component checks the **Title** field value and displays an error message if the value does not contain the **Sales** word.

![Implement Custom Validation in the Grid](/images/custom-validation.png)

## Overview

Follow the steps below to implement custom validation in a Grid component:

1. Add a [Grid](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid) component to a page and bind the component to data.

2. Enable edit operations in the Grid as described in the following topic: [Edit Data and Validate Input](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input).

3. Create a [validator component](https://learn.microsoft.com/en-us/aspnet/core/blazor/forms-and-input-components?view=aspnetcore-7.0#validator-components) that stores names of the fields that failed validation and the corresponding validation messages. Implement a `DataItemValidating` event that accepts the edit [model](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.model?view=aspnetcore-7.0) and a dictionary for field names and error messages as arguments. Invoke the event when the [edit context](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext?view=aspnetcore-7.0)'s [OnValidationRequested](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.onvalidationrequested?view=aspnetcore-7.0) and [OnFieldChanged](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.onfieldchanged?view=aspnetcore-7.0) events occur.

    ```cs
    public class MyCustomValidator : ComponentBase {
        private ValidationMessageStore MessageStore;
        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }
        [Parameter]
        public Action<ValidationMessageStoreEventArgs> DataItemValidating { get; set; }

        protected override void OnInitialized() {
            MessageStore = new(CurrentEditContext);
            CurrentEditContext.OnValidationRequested += (s, e) => ValidateData();
            CurrentEditContext.OnFieldChanged += (s, e) => ValidateData();
        }
        void ValidateData() {
            if (DataItemValidating == null)
                return;
            var errors = new Dictionary<string, List<string>>();
            var args = new ValidationMessageStoreEventArgs(CurrentEditContext.Model, errors);
            DataItemValidating.Invoke(args);
            // ...
        }
    }
    ```

4. Declare the validator component in the Grid's [CustomValidators](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.CustomValidators) template. In the validator component's `DataItemValidating` event handler, check field values and add error messages with names of the fields that failed validation to the dictionary.

    ```razor
    <DxGrid>
        <!-- ... -->
        <CustomValidators>
            <MyCustomValidator DataItemValidating="ValidateGridData" />
        </CustomValidators>
    </DxGrid>

    @code {
        void ValidateGridData(ValidationMessageStoreEventArgs e) {
            var employee = (Employee)e.EditModel;
            if (employee.Title == null || !employee.Title.Contains("Sales")) {
                e.AddError(nameof(employee.Title), "The Title field value should contain 'Sales'.");
            }
        }
    }
    ```

5. After you handle the `DataItemValidating` event, get the dictionary from the event arguments and copy data from this dictionary to the validation message store. Call the edit context's [NotifyValidationStateChanged](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.forms.editcontext.notifyvalidationstatechanged?view=aspnetcore-7.0) method to notify the Grid about the validation state change and display error messages.

    ```cs
    void ValidateData() {
        if (DataItemValidating == null)
            return;
        var errors = new Dictionary<string, List<string>>();
        var args = new ValidationMessageStoreEventArgs(CurrentEditContext.Model, errors);
        DataItemValidating.Invoke(args);
        
        MessageStore.Clear();
        foreach (var error in errors)
            MessageStore.Add(CurrentEditContext.Field(error.Key), error.Value);
        CurrentEditContext.NotifyValidationStateChanged();
    }
    ```

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
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-dxgrid-custom-validation&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-dxgrid-custom-validation&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
