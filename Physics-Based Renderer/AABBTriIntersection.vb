Imports Physics_Based_Renderer.Render
Public Module AABB_TriIntersection
    Dim X As Integer = 0
    Dim Y As Integer = 1
    Dim Z As Integer = 2
    Function crossProduct(ByVal vector1 As Render.vector3D, ByVal vector2 As Render.vector3D) As Render.vector3D
        Return New Render.vector3D(vector1.Y * vector2.Z - vector1.Z * vector2.Y, vector1.Z * vector2.X - vector1.X * vector2.Z, vector1.X * vector2.Y - vector1.Y * vector2.X)
    End Function
    Function dotProduct2D(ByVal vector1 As PointF, ByVal vector2 As PointF) As Double
        Dim length1 As Double = Math.Sqrt(vector1.X ^ 2 + vector1.Y ^ 2)
        Dim length2 As Double = Math.Sqrt(vector2.X ^ 2 + vector2.Y ^ 2)
        Return (vector1.X) * (vector2.X) + (vector1.Y) * (vector2.Y)
    End Function
    Function dotProduct3D(ByVal vector1 As Render.vector3D, ByVal vector2 As Render.vector3D) As Double
        Dim length1 As Double = Math.Sqrt(vector1.X ^ 2 + vector1.Y ^ 2)
        Dim length2 As Double = Math.Sqrt(vector2.X ^ 2 + vector2.Y ^ 2)
        Return (vector1.X) * (vector2.X) + (vector1.Y) * (vector2.Y) + (vector1.Z) * (vector2.Z)
    End Function
    Function vertexSubtract(ByVal vertex1 As Render.verticy3D, ByVal vertex2 As Render.verticy3D) As Render.vector3D
        Dim outputVector As New Render.vector3D(vertex1.X - vertex2.X, vertex1.Y - vertex2.Y, vertex1.Z - vertex2.Z)
        Return outputVector
    End Function
    Sub FINDMINMAX(ByVal x0, ByVal x1, ByVal x2, ByRef min, ByRef max)
        min = max = x0
        If x1 < min Then min = x1
        If x1 > max Then max = x1
        If x2 < min Then min = x2
        If x2 > max Then max = x2
    End Sub
    Public Function isIntersecting(ByVal inObject As object3D, ByVal faceNum As Integer, ByVal voxel As voxel) As Boolean
        If AabbAabbTest(inObject, faceNum, voxel) = True Then
            If AabbTriangleIntersectionTest(inObject, faceNum, voxel) = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Function AabbAabbTest(ByVal inObject As object3D, ByVal faceNum As Integer, ByVal voxel As voxel)
        Dim face As face3D = inObject.faces(faceNum - 1)
        Dim V1 As New verticy3D(inObject.verts(face.vert1 - 1).X, inObject.verts(face.vert1 - 1).Y, inObject.verts(face.vert1 - 1).Z)
        Dim V2 As New verticy3D(inObject.verts(face.vert2 - 1).X, inObject.verts(face.vert2 - 1).Y, inObject.verts(face.vert2 - 1).Z)
        Dim V3 As New verticy3D(inObject.verts(face.vert3 - 1).X, inObject.verts(face.vert3 - 1).Y, inObject.verts(face.vert3 - 1).Z)
        Dim primMin As verticy3D
        primMin.X = Math.Min(Math.Min(V1.X, V2.X), V3.X)
        primMin.Y = Math.Min(Math.Min(V1.Y, V2.Y), V3.Y)
        primMin.Z = Math.Min(Math.Min(V1.Z, V2.Z), V3.Z)
        Dim primMax As verticy3D
        primMax.X = Math.Max(Math.Max(V1.X, V2.X), V3.X)
        primMax.Y = Math.Max(Math.Max(V1.Y, V2.Y), V3.Y)
        primMax.Z = Math.Max(Math.Max(V1.Z, V2.Z), V3.Z)
        Dim voxelMin As verticy3D
        voxelMin.X = voxel.Xpos - voxel.size
        voxelMin.Y = voxel.Ypos - voxel.size
        voxelMin.Z = voxel.Zpos - voxel.size
        Dim voxelMax As verticy3D
        voxelMax.X = voxel.Xpos + voxel.size
        voxelMax.Y = voxel.Ypos + voxel.size
        voxelMax.Z = voxel.Zpos + voxel.size
        If ((primMax.X - voxelMin.X) * (primMin.X - voxelMax.X)) >= 0 Or ((primMax.Y - voxelMin.Y) * (primMin.Y - voxelMax.Y)) >= 0 Or ((primMax.Z - voxelMin.Z) * (primMin.X - voxelMax.Z)) >= 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Function AabbTriangleIntersectionTest(ByVal inObject As object3D, ByVal faceNum As Integer, ByVal voxel As voxel)
        Dim normalVector = inObject.faces(faceNum - 1).normal
        Dim normalArray = {normalVector.X, normalVector.Y, normalVector.Z}
        Dim vertArray = {inObject.verts(inObject.faces(faceNum))}
    End Function
    Function planeBoxOverlap(ByRef normal() As Double, ByRef vert(,) As Double, ByVal maxbox() As Double) As Integer
        Dim q As Integer = X
        Dim vmin(2), vmax(2), v(2) As Double
        Do Until q = Z
            v = {vert(0, q), vert(1, q), vert(2, q)}
            If normal(q) > 0 Then
                vmin(q) = (vmin(q) - maxbox(q)) - v
            End If
            q += 1
        Loop
    End Function
End Module
