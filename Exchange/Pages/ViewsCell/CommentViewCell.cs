﻿using System;
using Exchange.Configs;
using Exchange.Controls;
using Exchange.Models;
using Xamarin.Forms;

namespace Exchange.ViewCells
{
	public class CommentViewCell : ViewCell
	{
		private CustomImage _pictureImage;
		private Label _headerLabel;
		private Label _subheaderLabel;
		private Label _contentLabel;

		public CommentViewCell()
		{
			var maiLayout = new StackLayout
			{
				Padding = new Thickness(20, 0),
				Spacing = 20,
			};

			var containerLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Spacing = 15,
				Padding = new Thickness(10, 20, 10, 0),
			};
			maiLayout.Children.Add(containerLayout);

			#region Picture
			var imageLayout = new StackLayout();
			containerLayout.Children.Add(imageLayout);
			_pictureImage = new CustomImage
			{
				Aspect = Aspect.AspectFill,
				Source = "ic_picture_placeholder.png",
				HeightRequest = 60,
				WidthRequest = 60,
			};
			imageLayout.Children.Add(_pictureImage);
			#endregion

			#region Content
			var contentLayout = new StackLayout
			{
				Spacing = 0,
			};
			containerLayout.Children.Add(contentLayout);
			_headerLabel = new Label
			{
				Style = Styles.Title,
			};
			contentLayout.Children.Add(_headerLabel);

			_subheaderLabel = new Label
			{
				Style = Styles.Subtitle,
				Text = "User",
			};
			contentLayout.Children.Add(_subheaderLabel);

			_contentLabel = new Label
			{
				Style = Styles.Verbosa,
			};
			contentLayout.Children.Add(_contentLabel);
			#endregion


			maiLayout.Children.Add(UIHelper.UIHelper.Separator());

			View = maiLayout;
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			Comment comment = this.BindingContext as Comment;

			if (comment == null)
				return;

			if (comment.User != null)
			{
				if (!string.IsNullOrEmpty(comment.User.ProfilePicture))
					_pictureImage.Source = comment.User.ProfilePicture;
				if (!string.IsNullOrEmpty(comment.User.DisplayName))
					_headerLabel.Text = comment.User.DisplayName;
			}
			_subheaderLabel.Text = comment.CreatedAt.HumanDate();
			_contentLabel.Text = comment.Message;
			//_contentLabel.Text = Tools.TruncateText(comment.message, 100);

		}
	}
}


