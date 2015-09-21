Module Utill
    Function fromFile(text As List(Of String)) As Render.scene3D      'Function to turn text to a file
        Dim scene As New Render.scene3D
        Dim cameras As New Dictionary(Of String, Render.camera3D)
        Dim materials As New Dictionary(Of String, Render.material3D)
        Dim objects As New Dictionary(Of String, Render.object3D)
        scene.objects = New List(Of Render.object3D)
        For Each line In text
            If line.ToString.StartsWith("camera ") Then     'Camera coding conversion
                Dim camera As New Render.camera3D
                Dim cameraName As String = line.ToString.Substring(6).Split(" ")(1)
                camera.X = line.ToString.Split(" ")(2)
                camera.Y = line.ToString.Split(" ")(3)
                camera.Z = line.ToString.Split(" ")(4)
                camera.Xrot = line.ToString.Split(" ")(5)
                camera.Yrot = line.ToString.Split(" ")(6)
                camera.Zrot = line.ToString.Split(" ")(7)
                camera.Xres = line.ToString.Split(" ")(8)
                camera.Yres = line.ToString.Split(" ")(9)
                camera.FOV = line.ToString.Split(" ")(10)
                cameras.Add(cameraName, camera)
            ElseIf line.ToString.StartsWith("viewport ") Then 'Viewport coding conversion
                scene.camera = cameras(line.ToString.Split(" ")(1))
            ElseIf line.ToString.StartsWith("material ") Then 'Material coding conversion
                Dim material As Render.material3D
                material.rReflection = line.Split(" ")(2)
                material.gReflection = line.Split(" ")(3)
                material.bReflection = line.Split(" ")(4)
                material.rEmission = line.Split(" ")(5)
                material.gEmission = line.Split(" ")(6)
                material.bEmission = line.Split(" ")(7)
                material.roughness = line.Split(" ")(8)
                materials.Add(line.Split(" ")(1), material)
                scene.materials = materials
            ElseIf line.ToString.StartsWith("object ") Then  'Object coding conversion
                Dim verts As New List(Of Render.verticy3D)
                Dim faces As New List(Of Render.face3D)
                For Each vert In line.Split("{")(1).Split("}")(0).Split(",")
                    Dim x As String = vert.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(0).Trim.Trim({"("c, ")"c})
                    Dim y As String = vert.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(1).Trim.Trim({"("c, ")"c})
                    Dim z As String = vert.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(2).Trim.Trim({"("c, ")"c})
                    verts.Add(New Render.verticy3D(x, y, z))
                Next
                For Each face In line.Split("{")(2).Split("}")(0).Split(",")
                    Dim v1 As String = face.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(0).Trim.Trim({"("c, ")"c})
                    Dim v2 As String = face.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(1).Trim.Trim({"("c, ")"c})
                    Dim v3 As String = face.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(2).Trim.Trim({"("c, ")"c})
                    Dim material As String = face.Split(Space(1).ToCharArray, StringSplitOptions.RemoveEmptyEntries)(3).Trim.Trim({"("c, ")"c})
                    faces.Add(New Render.face3D(v1, v2, v3, material))
                Next
                scene.objects.Add(New Render.object3D(verts, faces))
            End If
        Next
        Return scene
    End Function
End Module