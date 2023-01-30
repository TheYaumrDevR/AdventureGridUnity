﻿namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class EarthBlockUvCoordinates : BlockUvCoordinates
    {
        private static EarthBlockUvCoordinates instance;
    
        public static EarthBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new EarthBlockUvCoordinates();
            }
        
            return instance;
        }      

        private readonly float[] uvCoordinates = {
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Front 
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Right
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Back
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Left
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2, // Bottom 
            1, 0, 2, 1, 1, 2, 0, 1, 2, 0, 0, 2 // Top
        };         

        private readonly float[] backUvCoordinates = {
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Front
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Right
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Back
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Left
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2, // Bottom 
            0, 0, 2, 0, 1, 2, 1, 1, 2, 1, 0, 2 // Top
        };               

        private EarthBlockUvCoordinates() {}  

        public override float[] GetUvCoordinates() 
        {
            return uvCoordinates;
        }
    
        public override float[] GetBackUvCoordinates() 
        {
            return backUvCoordinates;
        }
    }   
}