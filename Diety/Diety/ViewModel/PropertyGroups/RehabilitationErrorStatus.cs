using System;
using Diety.ViewModel.PropertyGroups.Interfaces;
using GalaSoft.MvvmLight;

namespace Diety.ViewModel.PropertyGroups
{
	class RehabilitationErrorStatus : ViewModelBase, IRehabilitationErrorStatus
	{

		#region Private Fields

		/// <summary>
		/// The _username error
		/// </summary>
		private string _usernameErrorMessage;

		/// <summary>
		/// The _password error
		/// </summary>
		private string _passwordErrorMessage;

		/// <summary>
		/// The _weight error
		/// </summary>
		private string _weightErrorMessage;

		/// <summary>
		/// The _height error
		/// </summary>
		private string _heightErrorMessage;

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets a value indicating whether [username error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [username error]; otherwise, <c>false</c>.
		/// </value>
		public bool UsernameError
		{
			get { return !String.IsNullOrEmpty(UsernameErrorMessage); }			
		}

		/// <summary>
		/// Gets or sets a value indicating whether [password error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [password error]; otherwise, <c>false</c>.
		/// </value>
		public bool PasswordError
		{
			get { return !String.IsNullOrEmpty(PasswordErrorMessage); }			
		}

		/// <summary>
		/// Gets or sets a value indicating whether [weight error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [weight error]; otherwise, <c>false</c>.
		/// </value>
		public bool WeightError
		{
			get { return !String.IsNullOrEmpty(WeightErrorMessage); }			
		}

		/// <summary>
		/// Gets or sets a value indicating whether [height error].
		/// </summary>
		/// <value>
		///   <c>true</c> if [height error]; otherwise, <c>false</c>.
		/// </value>
		public bool HeightError
		{
			get { return !String.IsNullOrEmpty(HeightErrorMessage); }			
		}

		/// <summary>
		/// Gets or sets a value indicating whether [no errors].
		/// </summary>
		/// <value>
		///   <c>true</c> if [no errors]; otherwise, <c>false</c>.
		/// </value>
		public bool NoErrors
		{
			get { return !(HeightError || WeightError || PasswordError || UsernameError); }			
		}

		/// <summary>
		/// Gets or sets the username error message.
		/// </summary>
		/// <value>
		/// The username error message.
		/// </value>
		public string UsernameErrorMessage
		{
			get
			{
				return _usernameErrorMessage;
			}
			set
			{
				Set(ref _usernameErrorMessage, value);
				RaisePropertyChanged(() => UsernameError);
				RaisePropertyChanged(() => NoErrors);
			}
		}

		/// <summary>
		/// Gets or sets the password error message.
		/// </summary>
		/// <value>
		/// The password error message.
		/// </value>
		public string PasswordErrorMessage
		{
			get
			{
				return _passwordErrorMessage;
			}
			set
			{
				Set(ref _passwordErrorMessage, value);
				RaisePropertyChanged(() => PasswordError);
				RaisePropertyChanged(() => NoErrors);
			}
		}

		/// <summary>
		/// Gets or sets the height error message.
		/// </summary>
		/// <value>
		/// The height error message.
		/// </value>
		public string HeightErrorMessage
		{
			get
			{
				return _heightErrorMessage;
			}
			set
			{
				Set(ref _heightErrorMessage, value);
				RaisePropertyChanged(() => HeightError);
				RaisePropertyChanged(() => NoErrors);
			}
		}

		/// <summary>
		/// Gets or sets the weight error message.
		/// </summary>
		/// <value>
		/// The weight error message.
		/// </value>
		public string WeightErrorMessage
		{
			get
			{
				return _weightErrorMessage;
			}
			set
			{
				Set(ref _weightErrorMessage, value);
				RaisePropertyChanged(() => WeightError);
				RaisePropertyChanged(() => NoErrors);
			}
		}

		#endregion
		#region C-tors

		/// <summary>
		/// Initializes a new instance of the <see cref="RehabilitationErrorStatus"/> class.
		/// </summary>
		public RehabilitationErrorStatus()
		{
			HeightErrorMessage = null;
			PasswordErrorMessage = null;
			UsernameErrorMessage = null;
			WeightErrorMessage = null;
		}

		#endregion
	}
}
