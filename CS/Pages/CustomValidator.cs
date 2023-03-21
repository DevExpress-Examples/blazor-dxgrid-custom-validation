using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CustomValidation.Pages {
    public class MyCustomValidator : ComponentBase {
        private ValidationMessageStore messageStore;

        [CascadingParameter]
        private EditContext CurrentEditContext { get; set; }

        [Parameter]
        public Action<EditContext> DataItemValidating { get; set; }

        protected override void OnInitialized() {
            if(CurrentEditContext == null) {
                throw new InvalidOperationException(
                    $"{nameof(MyCustomValidator)} requires a cascading " +
                    $"parameter of type {nameof(EditContext)}. " +
                    $"For example, you can use {nameof(MyCustomValidator)} " +
                    $"inside an {nameof(EditForm)}.");
            }

            messageStore = new(CurrentEditContext);

            CurrentEditContext.OnValidationRequested += (s, e) =>
                DataItemValidating.Invoke(CurrentEditContext);
            CurrentEditContext.OnFieldChanged += (s, e) =>
                DataItemValidating.Invoke(CurrentEditContext);
        }

        public void DisplayErrors(Dictionary<string, List<string>> errors) {
            foreach(var err in errors) {
                messageStore.Add(CurrentEditContext.Field(err.Key), err.Value);
            }
            CurrentEditContext.NotifyValidationStateChanged();
        }

        public void ClearErrors() {
            messageStore.Clear();
            CurrentEditContext.NotifyValidationStateChanged();
        }
    }
}
