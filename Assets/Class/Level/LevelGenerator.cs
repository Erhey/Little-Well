using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    public struct St_BlocPartiel
    {
        public Vector2 Vect;
        public string Name;
    }
    
    public GameObject G_wall;
    public GameObject G_portal;
    public GameObject G_Nosferapti;
    public GameObject G_NosferaptiShiney;
    public void generateLevel(Level Lvl)
    {

        GameObject LevelParent = new GameObject();
        LevelParent.name = "Level " + Lvl.levelNum;
        LevelParent.transform.SetParent(GameManager.Instance.MainParentLevel.transform);
        // Génération des Images des murs
            generateSpriteWall(Lvl.wallPosition, LevelParent);
        // Génération des colliders
            generateCollider(Lvl.wallPosition, LevelParent);
        // Génération des éventuels portails,
            generatePortal(Lvl.portal, LevelParent);
        // Generation Monstre

        if (!LevelManager.Instance.LevelIsCompleted[Lvl.levelNum]) {

            generateMonster(Lvl.monsterMatrix, LevelParent);
            if (MonsterManager.Instance.Monsters.Count == 0)
            {
                LevelManager.Instance.LevelIsCompleted[Lvl.levelNum] = true;
            }
        }   
        // Generation Piece
        // generatePiece
        // Generation Objects
        // generateObjects
    }

    public void generateSpriteWall(int[,] wall, GameObject parent)
    {
        for (int i = 0; i < LevelManager.Instance.NbrColonne; i++)
        {
            for (int j = 0; j < LevelManager.Instance.NbrLine; j++)
            {
                if (wall[i, j] != 0)
                {
                    //    GameObject tile = GameObject.Instantiate(G_empt);
                    //    tile.name = "empty_CO";
                    //    tile.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
                    //}
                    //else
                    //{
                    GameObject tile = GameObject.Instantiate(G_wall);
                    tile.name = "wall_" + i + j;
                    tile.transform.localPosition = new Vector2(-9.5f +  i, 14.5f - j);
                    tile.transform.SetParent(parent.transform);
                }
                //if (actualLevel.piecePosition[i, j] == 0)
                //{
                //    //   Debug.Log("azertyuiop");
                //    LevelManager.pieceStruct buf = new LevelManager.pieceStruct();
                //    buf.i = i;
                //    buf.j = j;
                //    buf.piece = GameObject.Instantiate(G_piece);
                //    buf.piece.name = "piece" + i + j;
                //    buf.piece.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
                //    LevelManager.Instance.pieceList.Add(buf);
                //}
                //if (actualLevel.monsterPosition[i, j] == 1)
                //{
                //    //   Debug.Log("azertyuiop");
                //    GameObject monster = GameObject.Instantiate(GestionMonster.Instance.basicMonster);
                //    monster.name = "monster" + i + j;
                //    monster.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
                //    monster.SetActive(true);
                //    GestionMonster.Instance.nbrMonster++;
                //    GestionMonster.Instance.monsterList.Add(monster);
                //}
            }
        }
        //int[,] blocMatrix = new int[15, 25];
        //blocMatrix = CreateBlocMatrix(wall);

        //GenerateBlocs(blocMatrix);
        //GenerateCollider(blocMatrix);
    }

    public void generateCollider(int[,] blocMatrix,GameObject parent)
    {
        int NbrBloc = 0;
        for (int j = 0; j < LevelManager.Instance.NbrLine; j++)
        {
            for (int i = 0; i < LevelManager.Instance.NbrColonne; i++)
            {
                if (i == 0)
                {
                    NbrBloc = 0;
                    if (blocMatrix[i, j] != 0)
                    {
                        NbrBloc++;
                    }
                }
                else
                {
                    if (blocMatrix[i, j] != 0)
                    {
                        NbrBloc++;
                    }
                    else
                    {
                        if (NbrBloc > 1)
                        {
                            CreateColliderLigne(NbrBloc, i, j, parent);
                        }
                        NbrBloc = 0;
                    }
                    if (i == LevelManager.Instance.NbrColonne - 1 && NbrBloc > 1)
                    {
                        CreateColliderLigne(NbrBloc, i+1, j, parent);
                    }
                }
            }
        }
        for (int i = 0; i < LevelManager.Instance.NbrColonne; i++)
        {
            for (int j = 0; j < LevelManager.Instance.NbrLine; j++)
            {
                if (j == 0)
                {
                    NbrBloc = 0;
                    if (blocMatrix[i, j] != 0)
                    {
                        NbrBloc++;
                    }
                }
                else
                {
                    if (blocMatrix[i, j] != 0)
                    {
                        NbrBloc++;
                    }
                    else
                    {
                        if (i == 0)
                        {
                            if (NbrBloc > 1 || (NbrBloc == 1 && (blocMatrix[i+1, j-1] == 0)))
                            {
                                CreateColliderColonne(NbrBloc, i, j, parent);
                            }
                            NbrBloc = 0;
                        }
                        else if (i == LevelManager.Instance.NbrColonne-1)
                        {
                            if (NbrBloc > 1 || (NbrBloc == 1 && blocMatrix[i-1, j-1] == 0))
                            {
                                CreateColliderColonne(NbrBloc, i, j, parent);
                            }
                            NbrBloc = 0;
                        }
                        else
                        {
                            if (NbrBloc > 1 || (NbrBloc == 1 && (blocMatrix[i - 1, j-1] == 0 && blocMatrix[i + 1, j-1] == 0)))
                            {
                                CreateColliderColonne(NbrBloc, i, j, parent);
                            }
                            NbrBloc = 0;
                        }

                    }
                }
            }
        }
        //int max = blocMatrix.Cast<int>().Max();
        //Debug.Log(max);
        //List<GameObject> OL_BlocCollider = new List<GameObject>();
        //for (int k = 0; k < max; k++)
        //{
        //    OL_BlocCollider.Add(new GameObject());
        //}

        //for (int i = 0; i < 15; i++)
        //{
        //    for (int j = 0; j < 25; j++)
        //    {
        //        if (blocMatrix[i, j] != 0)
        //        {
        //            BoxCollider2D newBoxCollider = OL_BlocCollider[blocMatrix[i, j] - 1].AddComponent<BoxCollider2D>();
        //            newBoxCollider.size = new Vector2(0.4f, 0.4f);
        //            newBoxCollider.offset = new Vector2(-2.8f + 0.4f * i, -4.8f + 0.4f * j);
        //        }
        //    }
        //}
    }

    public void generateMonster(int[,] monsterMatrix, GameObject parent)
    {
        for (int i = 0; i < LevelManager.Instance.NbrColonne; i++)
        {
            for (int j = 0; j < LevelManager.Instance.NbrLine; j++)
            {
                if (monsterMatrix[i, j] == 1)
                {
                    Debug.Log("test1");
                    GameObject monster = GameObject.Instantiate(G_Nosferapti);
                    monster.SetActive(true);
                    monster.name = "Nosferapti" + i + j;
                    monster.transform.localPosition = new Vector2(-9.5f + i, 14.5f - j);
                    monster.transform.SetParent(parent.transform);
                }
                else if (monsterMatrix[i, j] == 2)
                {
                    Debug.Log("test1");
                    GameObject monster = GameObject.Instantiate(G_NosferaptiShiney);
                    monster.SetActive(true);
                    monster.name = "NosferaptiShiney" + i + j;
                    monster.transform.localPosition = new Vector2(-9.5f + i, 14.5f - j);
                    monster.transform.SetParent(parent.transform);
                }
            }
        }
    }

    public GameObject CreateColliderLigne(int NbrBloc, int i, int j, GameObject parent)
    {
        GameObject ColliderLine = new GameObject("WallLine_" + j + "_" + (i - NbrBloc) + "to" + (i - 1));
        BoxCollider2D BoxLine = ColliderLine.AddComponent<BoxCollider2D>();
        ColliderLine.transform.position = new Vector2(-(LevelManager.Instance.NbrColonne / 2f) + (i - (0.5f * NbrBloc)), (LevelManager.Instance.NbrLine - 1f) / 2f - j);
        BoxLine.size = new Vector2(NbrBloc - 0.01f, 1f);
        ColliderLine.transform.SetParent(parent.transform);
        return ColliderLine;
    }
    public GameObject CreateColliderColonne(int NbrBloc, int i, int j, GameObject parent)
    {
        GameObject ColliderColonne= new GameObject("WallColonne_" + i + "_" + (j - NbrBloc) + "to" + (j - 1));
        BoxCollider2D BoxLine = ColliderColonne.AddComponent<BoxCollider2D>();
        ColliderColonne.transform.position = new Vector2(-(LevelManager.Instance.NbrColonne - 1f) / 2f + i, (LevelManager.Instance.NbrLine) / 2f - (j - (0.5f * NbrBloc)));
        BoxLine.size = new Vector2(1, NbrBloc-0.01f);
        ColliderColonne.transform.SetParent(parent.transform);
        return ColliderColonne;
    }

    public void generatePortal(CaracteristicPortal portal , GameObject parent)
    {
        Debug.Log(parent.name);
        if (portal.posX != 100)
        {
            GameObject NewPortal = GameObject.Instantiate(G_portal);
            NewPortal.name = "Portal_ActualLvl="+ portal.originLevelNum;
            NewPortal.GetComponent<PortalBehavior>().Portal = portal;
            NewPortal.transform.position = new Vector3(portal.posX, portal.posY, 0);
            NewPortal.transform.SetParent(parent.transform);
        }
    }

    public void MoveLevel(GameManager.Direction dir, int LevelNum)
    {
        GameObject LevelParent = GameObject.Find("Level " + LevelNum);
        switch (dir)
        {
            case GameManager.Direction.Up:
                LevelParent.transform.position = new Vector3(LevelParent.transform.position.x, LevelParent.transform.position.y + 30, LevelParent.transform.position.z);
                break;
            case GameManager.Direction.Right:
                LevelParent.transform.position = new Vector3(LevelParent.transform.position.x + 20, LevelParent.transform.position.y, LevelParent.transform.position.z);
                break;
            case GameManager.Direction.Down:
                LevelParent.transform.position = new Vector3(LevelParent.transform.position.x, LevelParent.transform.position.y - 30, LevelParent.transform.position.z);
                break;
            case GameManager.Direction.Left:
                LevelParent.transform.position = new Vector3(LevelParent.transform.position.x - 20, LevelParent.transform.position.y, LevelParent.transform.position.z);
                break;
            case GameManager.Direction.other:
                Debug.Log(dir);
                break;
            default:
                Debug.Log(dir);
                break;
        }

    }
}

//public int[,] CreateBlocMatrix(int[,] wall)
//{
//    int[,] RV_blocMatrix = new int[15, 25];
//    int IteratorBloc = 0;
//    int[] closeWallValue = new int[2];
//    for (int i = 0; i < 15; i++)
//    {
//        for (int j = 0; j < 25; j++)
//        {
//            if (wall[i, j] == 1)
//            {
//                closeWallValue[0] = RV_blocMatrix[Mathf.Max(0, i - 1), j];
//                closeWallValue[1] = RV_blocMatrix[i, Mathf.Max(0, j - 1)];

//                CAS 1 no wall up/left
//                if (Mathf.Max(closeWallValue) == 0)
//                {
//                    IteratorBloc++;
//                    RV_blocMatrix[i, j] = IteratorBloc;
//                }
//                 Wall for 1 only
//                else if (Mathf.Max(closeWallValue) > 0 && Mathf.Min(closeWallValue) == 0)
//                {
//                    RV_blocMatrix[i, j] = Mathf.Max(closeWallValue);
//                }
//                 Wall for 2 Same value
//                else if (Mathf.Max(closeWallValue) > 0 && Mathf.Min(closeWallValue) > 0)
//                {
//                    if (Mathf.Max(closeWallValue) == Mathf.Min(closeWallValue))
//                    {
//                        RV_blocMatrix[i, j] = Mathf.Max(closeWallValue);
//                    }
//                    else
//                    {
//                        RV_blocMatrix[i, j] = Mathf.Min(closeWallValue);
//                        for (int l = 0; l < 15; l++)
//                        {
//                            for (int k = 0; k < 25; k++)
//                            {
//                                if (RV_blocMatrix[l, k] == Mathf.Max(closeWallValue))
//                                {
//                                    RV_blocMatrix[l, k] = Mathf.Min(closeWallValue);
//                                }
//                            }
//                        }
//                    }

//                }
//            }
//        }
//    }
//    return RV_blocMatrix;
//}
//GameObject bloc;
//bloc = new GameObject("blocX");
//bloc.AddComponent<EdgeCollider2D>();
//List<St_BlocPartiel> MeshBloc = new List<St_BlocPartiel>();
//for (int i = 0; i < 15; i++)
//{
//    for (int j = 0; j < 25; j++)
//    {
//        Vector2[] vectTest = new Vector2[5];
//        vectTest[0] = new Vector2(-2.6f + 0.4f * i, 5f - 0.4f * j);
//        vectTest[1] = new Vector2(-3f + 0.4f * i, 5f - 0.4f * j);
//        vectTest[2] = new Vector2(-3f + 0.4f * i, 4.6f - 0.4f * j);
//        if (i != 0)
//        {
//            if (j != 0)
//            {
//                MeshBloc = modifieBlock(MeshBloc, vectTest, blocMatrix[i, j], blocMatrix[i - 1, j], blocMatrix[i, j - 1]);
//            }
//            else
//            {
//                MeshBloc = modifieBlock(MeshBloc, vectTest, blocMatrix[i, j], blocMatrix[i - 1, j]);
//            }
//        }
//        else
//        {
//            if (j != 0)
//            {
//                MeshBloc = modifieBlock(MeshBloc, vectTest, blocMatrix[i, j], 0, blocMatrix[i, j - 1]);
//            }
//            else
//            {
//                MeshBloc = modifieBlock(MeshBloc, vectTest, blocMatrix[i, j]);
//            }
//        }
//        MeshBloc = modifieBlock(MeshBloc, vectTest, blocMatrix[i, j]);

//    }
//}
//bloc.GetComponent<EdgeCollider2D>().points = new Vector2[10];
//}
//public List<St_BlocPartiel> modifieBlock(List<St_BlocPartiel> actualBloc, Vector2[] nextWall, int BlocNumber, int Left = 0, int Up = 0)
//{

//    if (BlocNumber == 0)
//    {
//        if (Left != 0 && Up != 0)
//        {
//             A FAIRE
//        }
//        if (Left != 0 && Up == 0)
//        {
//             A FAIRE
//        }
//        if (Left == 0 && Up != 0)
//        {
//            St_BlocPartiel NewMesh1;
//            NewMesh1.Vect = nextWall[0];
//            NewMesh1.Name = mFindNameMesh(actualBloc, nextWall[1], Left, in));
//            NewMesh1.Name = 
//            actualBloc.Add()
//        }
//    }
//    else
//    {
//        if (Left != 0 && Up != 0)
//        {
//             A FAIRE
//        }
//        if (Left != 0 && Up == 0)
//        {
//             A FAIRE
//        }
//        if (Left == 0 && Up != 0)
//        {
//             A FAIRE
//        }
//        if (Left == 0 && Up == 0)
//        {
//             A FAIREj,n
//        }
//    }
//    return actualBloc;
//}
//public string mFindNameMesh(List<St_BlocPartiel> actualBloc, Vector2 NewMesh, int Left, int Up)
//{
//    for(int i = 0; i < actualBloc.Count; i++)
//    {
//        if(actualBloc[i].Vect == NewMesh)
//        {

//        }
//    }

//    return"::";
//}
//}

//        for (int i = 0; i < 15; i++)
//        {
//            for (int j = 0; j < 25; j++)
//            {


//                if (actualLevel.wallPosition[i, j] == 1)
//                {
//                    GameObject tile = GameObject.Instantiate(G_blanc);
//                    tile.name = "empty";
//                    tile.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
//                }
//                else
//                {
//                    GameObject tile = GameObject.Instantiate(G_noir);
//                    tile.name = "wall";
//                    tile.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
//                    groupBloc[it] = tile;
//                    it++;
//                }
//                if (actualLevel.piecePosition[i, j] == 0)
//                {
//                    //   Debug.Log("azertyuiop");
//                    LevelManager.pieceStruct buf = new LevelManager.pieceStruct();
//                    buf.i = i;
//                    buf.j = j;
//                    buf.piece = GameObject.Instantiate(G_piece);
//                    buf.piece.name = "piece" + i + j;
//                    buf.piece.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
//                    LevelManager.Instance.pieceList.Add(buf);
//                }
//                if (actualLevel.monsterPosition[i, j] == 1)
//                {
//                    //   Debug.Log("azertyuiop");
//                    GameObject monster = GameObject.Instantiate(GestionMonster.Instance.basicMonster);
//                    monster.name = "monster" + i + j;
//                    monster.transform.localPosition = new Vector2(-2.8f + 0.4f * i, 4.8f - 0.4f * j);
//                    monster.SetActive(true);
//                    GestionMonster.Instance.nbrMonster++;
//                    GestionMonster.Instance.monsterList.Add(monster);
//                }
//            }
//        }
//    }
//    IEnumerator destroyPreviousLevel()
//    {
//        yield return new WaitForSeconds(1);
//        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
//        {
//            if (o.name.Equals("empty") || o.name.Equals("wall"))
//                Destroy(o);
//        }
//    }
//    IEnumerator animLevelUp()
//    {
//        yield return new WaitForSeconds(0.1f);
//        if (numLevel != 1)
//        {
//            float alpha = 0;
//            for (int i = 0; i < 10; i++)
//            {
//                alpha += 0.1f;
//                LevelManager.Instance.rideauNoir.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
//                yield return new WaitForSeconds(0.05f);

//            }
//            yield return new WaitForSeconds(0.5f);
//            for (int i = 0; i < 10; i++)
//            {
//                alpha -= 0.1f;
//                LevelManager.Instance.rideauNoir.GetComponent<Image>().color = new Color(1, 1, 1, alpha);
//                yield return new WaitForSeconds(0.05f);

//            }
//            LevelManager.Instance.rideauNoir.GetComponent<Image>().color = new Color(1, 1, 1, 0);
//        }
//    }
//    public void changeLevel()
//    {
//        LevelManager.Instance.refPers.transform.position = new Vector2(LevelManager.Instance.refPers.transform.position.x, 10.5f);
//        LevelManager.Instance.refPers.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
//        //Debug.Log ("c'est bien, c'est beau, c'est moche");
//        return;
//    }
//    //private IEnumerator triggerSetter(){
//    //	LevelManager.Instance.refPers.GetComponent<Collider2D> ().isTrigger = true;
//    //	yield return new WaitForSeconds(1);
//    //	LevelManager.Instance.refPers.GetComponent<Collider2D>().isTrigger = false;
//    //}


//}
