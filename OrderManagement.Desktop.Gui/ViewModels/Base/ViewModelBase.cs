using System;
using System.Threading.Tasks;
using OrderManagement.DataAccess.Entities;

namespace OrderManagement.Desktop.Gui.ViewModels.Base
{
    /// <summary>
    /// Base class for ViewModel classes
    /// </summary>
    public class ViewModelBase : BindableBase
    {
        #region Methods
        /// <summary>
        /// Runs the <see cref="LoadAllAsync"/> method
        /// </summary>
        public virtual async Task InitializeAsync()
        {
            // Load suppliers
            await LoadAllAsync();
        }

        /// <summary>
        /// Loads data from the database
        /// </summary>
        protected virtual Task LoadAllAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
