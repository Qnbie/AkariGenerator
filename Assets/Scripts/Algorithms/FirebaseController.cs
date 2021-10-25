using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace Algorithms
{
    public class FirebaseController
    {
        private DatabaseReference _dBReference;
        
        public FirebaseController()
        {
             FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }
        
        private void InitializeFirebase()
        {
            Debug.Log("Setting up Firebase Auth");
            _dBReference = FirebaseDatabase.DefaultInstance.RootReference;
            if (_dBReference == null) Debug.Log("Failed to Setting up Firebase Auth");
        }

        public List<RawPuzzle> GetPuzzle(Difficulty difficulty)
        {
            FirebaseDatabase.DefaultInstance
                .GetReference("puzzles")
                .EqualTo((double)difficulty, "Difficulty")
                .GetValueAsync()
                .ContinueWithOnMainThread(task => {
                    if (task.IsFaulted) {
                        // Handle the error...
                    }
                    else if (task.IsCompleted) {
                        DataSnapshot snapshot = task.Result;
                        
                    }
                });
            return new List<RawPuzzle>();
        }

        public void AddPuzzle(RawPuzzle rawPuzzle)
        {
            Debug.Log("Start adding methode");
            if (rawPuzzle != null) AddPuzzleToDatabase(rawPuzzle);
            else Debug.Log("FAIL");
        }

        private void AddPuzzleToDatabase(RawPuzzle rawPuzzle)
        {
            string jsonPuzzle = JsonUtility.ToJson(rawPuzzle);
            _dBReference.SetRawJsonValueAsync(jsonPuzzle);
        }

        public void RemovePuzzle(string key)
        {
            FirebaseDatabase.DefaultInstance
                .GetReference("puzzles").Child(key).RemoveValueAsync();
        }
    }
}