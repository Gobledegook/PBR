Public Class Render
    Structure splat
        Dim X As Double
        Dim Y As Double
        Dim R As Double
        Dim G As Double
        Dim B As Double
    End Structure
    Structure vector3D
        Dim X As Double
        Dim Y As Double
        Dim Z As Double
        Sub New(ByVal inputX, ByVal inputY, ByVal inputZ)
            X = inputX
            Y = inputY
            Z = inputZ
        End Sub
    End Structure
    Structure voxel
        Dim Xpos As Double
        Dim Ypos As Double
        Dim Zpos As Double
        Dim size As Double
        Dim faceData As List(Of face3D)
        Sub New(ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal voxelSize As Double)
            Xpos = X
            Ypos = Y
            Zpos = Z
            size = voxelSize
        End Sub
        Sub New(ByVal X As Double, ByVal Y As Double, ByVal Z As Double, ByVal voxelSize As Double, ByVal faceData As List(Of face3D))
            Xpos = X
            Ypos = Y
            Zpos = Z
            size = voxelSize
        End Sub
    End Structure
    Structure material3D                          'Material Structure
        Dim rReflection As Double
        Dim gReflection As Double
        Dim bReflection As Double
        Dim rEmission As Double
        Dim gEmission As Double
        Dim bEmission As Double
        Dim roughness As Double
        Sub New(ByRef newRReflection, ByVal newGReflection, ByVal newBReflection, ByVal newREmission, ByVal newGEmission, ByVal newBEmission, ByVal newRoughness)
            rReflection = newRReflection
            gReflection = newGReflection
            bReflection = newBReflection
            rEmission = newREmission
            gEmission = newGEmission
            bEmission = newBEmission
            roughness = newRoughness
        End Sub
    End Structure
    Structure verticy3D                            'Verticy Structure
        Dim X As Double
        Dim Y As Double
        Dim Z As Double
        Sub New(ByVal newX As Double, ByVal newY As Double, ByVal newZ As Double)
            X = newX
            Y = newY
            Z = newZ
        End Sub
    End Structure
    Structure edge3D                                'Edge Structure(for cube slicing)
        Dim V1 As verticy3D
        Dim v2 As verticy3D
        Sub New(ByVal verticy1 As verticy3D, ByVal verticy2 As verticy3D)
            V1 = verticy1
            v2 = verticy2
        End Sub
    End Structure
    Structure face3D                               'Face Structure
        Dim vert1 As Integer
        Dim vert2 As Integer
        Dim vert3 As Integer
        Dim material As String
        Dim normal As vector3D
        Sub New(ByVal newVert1 As Integer, ByVal newVert2 As Integer, ByVal newVert3 As Integer, ByVal newMaterial As String)
            vert1 = newVert1
            vert2 = newVert2
            vert3 = newVert3
            material = newMaterial
        End Sub
        Sub New(ByVal newVert1 As Integer, ByVal newVert2 As Integer, ByVal newVert3 As Integer, ByVal newMaterial As String, ByVal inputNormal As vector3D)
            vert1 = newVert1
            vert2 = newVert2
            vert3 = newVert3
            material = newMaterial
            normal = inputNormal
        End Sub
    End Structure
    Structure object3D                            'Object Structure(encapulates the verticy and face structures)
        Dim verts As List(Of verticy3D)
        Dim faces As List(Of face3D)
        Sub New(newVerts As List(Of verticy3D), newFaces As List(Of face3D))
            verts = newVerts
            faces = newFaces
        End Sub
    End Structure
    Structure camera3D                            'Camera Structure
        Dim X As Double
        Dim Y As Double
        Dim Z As Double
        Dim Xrot As Double
        Dim Yrot As Double
        Dim Zrot As Double
        Dim Xres As Integer
        Dim Yres As Integer
        Dim FOV As Integer
    End Structure
    Structure scene3D                              'Scene Structure(encapulates all the other structure)
        Dim camera As camera3D
        Dim objects As List(Of object3D)
        Dim materials As Dictionary(Of String, material3D)
    End Structure
    Public Sub getNormals(ByRef scene As scene3D)
        Dim objects As New List(Of object3D)
        For Each obj In scene.objects
            Dim facesInObj As New List(Of face3D)
            For Each face In obj.faces
                Dim vertex1 As verticy3D = obj.verts(face.vert1 - 1)
                Dim vertex2 As verticy3D = obj.verts(face.vert2 - 1)
                Dim vertex3 As verticy3D = obj.verts(face.vert3 - 1)
                Dim U As vector3D = vertexSubtract(vertex2, vertex1)
                Dim V As vector3D = vertexSubtract(vertex3, vertex1)
                Dim normalX As Double = (U.Y * V.Z) - (U.Z * V.Y)
                Dim normalY As Double = (U.Z * V.X) - (U.X * V.Z)
                Dim normalZ As Double = (U.X * V.Y) - (U.Y * V.X)
                Dim normalizationFactor As Double = Math.Sqrt((normalX ^ 2) + (normalY ^ 2) + (normalZ ^ 2))
                Dim normal As New vector3D(normalX / normalizationFactor, normalY / normalizationFactor, normalZ / normalizationFactor)
                Dim faceNormal As New face3D
                faceNormal = face
                faceNormal.normal = normal
                facesInObj.Add(faceNormal)
            Next
            Dim objectToAdd As object3D
            objectToAdd = obj
            objectToAdd.faces = facesInObj
            objects.Add(objectToAdd)
        Next
        scene.objects = objects
    End Sub
    Function subdivideVoxels(voxels As List(Of voxel)) As List(Of voxel)
        Dim voxelSubdivisions As New List(Of verticy3D)({New verticy3D(0.5, 0.5, 0.5), New verticy3D(0.5, 0.5, -0.5), New verticy3D(0.5, -0.5, -0.5), New verticy3D(-0.5, -0.5, -0.5), New verticy3D(-0.5, 0.5, 0.5), New verticy3D(-0.5, -0.5, 0.5), New verticy3D(0.5, -0.5, -0.5), New verticy3D(-0.5, 0.5, -0.5)}.ToList)
        Dim returnVoxels = voxels
        Dim forVoxels = voxels
        For Each inputVoxel In forVoxels
            returnVoxels.Remove(inputVoxel)
            For i = 0 To 7
                returnVoxels.Add(New voxel(voxelSubdivisions(i).X * inputVoxel.size + inputVoxel.Xpos, voxelSubdivisions(i).Y * inputVoxel.size + inputVoxel.Ypos, voxelSubdivisions(i).Z * inputVoxel.size + inputVoxel.Zpos, inputVoxel.size / 2))
            Next
        Next
        Return returnVoxels
    End Function
    Public Function createVoxels(scene As scene3D) As List(Of voxel)
        Dim voxels As List(Of voxel) = {New voxel(500, 500, 500, 500), New voxel(500, 500, -500, 500), New voxel(-500, 500, 500, 500), New voxel(-500, 500, -500, 500), New voxel(500, -500, 500, 500), New voxel(500, -500, -500, 500), New voxel(-500, -500, 500, 500), New voxel(-500, -500, -500, 500)}.ToList
        Dim allculled As Boolean
        Do Until allculled
            Dim notculledvoxels = voxels
            For index = 0 To voxels.Count - 1
                If voxels.Item(index).size = 0.1 Then
                    notculledvoxels.Remove(voxels.Item(index))
                End If
            Next
            allculled = (notculledvoxels.Count = 0)
            Dim toSubdivide As New List(Of voxel)
            For Each ittobject In scene.objects
                For index = 0 To ittobject.faces.Count - 1
                    For Each ittvoxel In notculledvoxels
                        If AABB_TriIntersection.isIntersecting(ittobject, index + 1, ittvoxel) Then
                            toSubdivide.Add(ittvoxel)
                        End If
                    Next
                Next
            Next
            subdivideVoxels(toSubdivide)
        Loop
        Return voxels
    End Function
    Public Function renderImage(scene As scene3D, voxels As List(Of voxel), xRes As Integer, yRes As Integer) As Object
        Dim pixels(scene.camera.Xres, scene.camera.Yres) As List(Of splat)
        Return pixels
    End Function
    Public Function render(sceneInput As scene3D) As Object
        Dim scene As scene3D = sceneInput
        getNormals(scene)
        Dim voxels As List(Of voxel) = createVoxels(scene)
        Stop
        Dim renderedImage(scene.camera.Xres, scene.camera.Yres) As List(Of splat)
        renderedImage = renderImage(scene, voxels, scene.camera.Xres, scene.camera.Yres)
        Return renderedImage
    End Function
End Class