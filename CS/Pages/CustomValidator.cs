using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CustomValidation.Pages {
    public class ValidationMessageStoreEventArgs : EventArgs {
        public ValidationMessageStoreEventArgs(object model, Dictionary<string, List<string>> errors) {
            EditModel = model;
            Errors = errors;
        }
        public object EditModel { get; }
        private Dictionary<string, List<string>> Errors { get; }
        public void AddError(string fieldName, string errorText) {
            if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(errorText))
                return;
            if (!Errors.ContainsKey(fieldName))
                Errors[fieldName] = new List<string>();
            Errors[fieldName].Add(errorText);
        }
    }
    public class MyCustomValidator : ComponentBase {
        private ValidationMessageStore MessageStore;
        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }
        [Parameter]
        public Action<ValidationMessageStoreEventArgs> DataItemValidating { get; set; }
        protected override void OnInitialized() {
            if (CurrentEditContext == null) {
                throw new InvalidOperationException(
                    $"{nameof(MyCustomValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(MyCustomValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }
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

            MessageStore.Clear();
            foreach (var error in errors)
                MessageStore.Add(CurrentEditContext.Field(error.Key), error.Value);
            CurrentEditContext.NotifyValidationStateChanged();
        }
    }
}
