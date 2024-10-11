Public Class TapDrillDepth_Setting
  Dim DimChanged As Boolean = False
  Dim MultiplierChanged As Boolean = False

  Private Sub ApplyButton_Click(sender As Object, e As EventArgs) Handles ApplyButton.Click
    If DimChanged Then
      My.Settings.DrillDepthTrigger = DimTextBox.Text
    End If
    If MultiplierChanged Then
      My.Settings.DrillDepthMultiplier = MultiplierTextBox.Text
    End If
    My.Settings.Save()
    Me.Close()
  End Sub

  Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
    Me.Close()
  End Sub

  Private Sub DimTextBox_TextChanged(sender As Object, e As EventArgs) Handles DimTextBox.TextChanged
    DimChanged = True
  End Sub

  Private Sub MultiplierTextBox_TextChanged(sender As Object, e As EventArgs) Handles MultiplierTextBox.TextChanged
    MultiplierChanged = True
  End Sub
End Class