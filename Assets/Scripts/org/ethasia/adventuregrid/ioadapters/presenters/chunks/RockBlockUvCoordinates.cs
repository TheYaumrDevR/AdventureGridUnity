﻿namespace Org.Ethasia.Adventuregrid.Ioadapters.Presenters.Chunks
{
    public class RockBlockUvCoordinates : BlockUvCoordinates
    {
        private static RockBlockUvCoordinates instance;
    
        public static RockBlockUvCoordinates GetInstance() 
        {
            if (null == instance) 
            {
                instance = new RockBlockUvCoordinates();
            }
        
            return instance;
        } 

        private readonly float[] uvCoordinates = {
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0, // Front
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0, // Right
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0, // Back
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0, // Left
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0, // Bottom 
            0.25f, 0, 0.25f, 0.015625f, 0.1875f, 0.015625f, 0.1875f, 0 // Top  
        };        

        private readonly float[] backUvCoordinates = {
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0, // Front
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0, // Right
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0, // Back
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0, // Left
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0, // Bottom 
            0.1875f, 0, 0.1875f, 0.015625f, 0.25f, 0.015625f, 0.25f, 0 // Top  
        };         

        private RockBlockUvCoordinates() {}

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