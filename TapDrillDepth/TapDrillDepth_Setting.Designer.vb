<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TapDrillDepth_Setting
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TapDrillDepth_Setting))
    Me.DimTextBox = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.MultiplierTextBox = New System.Windows.Forms.TextBox()
    Me.ApplyButton = New System.Windows.Forms.Button()
    Me.Cancel_Button = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'DimTextBox
    '
    Me.DimTextBox.Location = New System.Drawing.Point(110, 12)
    Me.DimTextBox.Name = "DimTextBox"
    Me.DimTextBox.Size = New System.Drawing.Size(49, 20)
    Me.DimTextBox.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 12)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Trigger Dimension"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 47)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(48, 13)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Multiplier"
    '
    'MultiplierTextBox
    '
    Me.MultiplierTextBox.Location = New System.Drawing.Point(110, 47)
    Me.MultiplierTextBox.Name = "MultiplierTextBox"
    Me.MultiplierTextBox.Size = New System.Drawing.Size(49, 20)
    Me.MultiplierTextBox.TabIndex = 3
    '
    'ApplyButton
    '
    Me.ApplyButton.Location = New System.Drawing.Point(179, 12)
    Me.ApplyButton.Name = "ApplyButton"
    Me.ApplyButton.Size = New System.Drawing.Size(75, 23)
    Me.ApplyButton.TabIndex = 4
    Me.ApplyButton.Text = "Apply"
    Me.ApplyButton.UseVisualStyleBackColor = True
    '
    'Cancel_Button
    '
    Me.Cancel_Button.Location = New System.Drawing.Point(179, 47)
    Me.Cancel_Button.Name = "Cancel_Button"
    Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
    Me.Cancel_Button.TabIndex = 5
    Me.Cancel_Button.Text = "Cancel"
    Me.Cancel_Button.UseVisualStyleBackColor = True
    '
    'TapDrillDepth_Setting
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(266, 84)
    Me.Controls.Add(Me.Cancel_Button)
    Me.Controls.Add(Me.ApplyButton)
    Me.Controls.Add(Me.MultiplierTextBox)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.DimTextBox)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "TapDrillDepth_Setting"
    Me.Text = "Tap Drill Depth Setting"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents DimTextBox As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents MultiplierTextBox As System.Windows.Forms.TextBox
  Friend WithEvents ApplyButton As System.Windows.Forms.Button
  Friend WithEvents Cancel_Button As System.Windows.Forms.Button
End Class
