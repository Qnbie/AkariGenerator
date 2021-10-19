using System.Collections;
using System.Collections.Generic;
using Enums;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using Utils.DataStructures;

namespace Algorithms
{
    public class FirebaseController
    {
        private DatabaseReference _dBReference;
        
        public FirebaseController()
        {
            //Check that all of the necessary dependencies for Firebase are present on the system
            FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus == DependencyStatus.Available)
                {
                    //If they are avalible Initialize Firebase
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
            //Set the authentication instance object
            _dBReference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        public List<RawPuzzle> GetPuzzle(Difficulty difficulty)
        {
            FirebaseDatabase.DefaultInstance
                .GetReference("puzzles").EqualTo((double)difficulty, "Difficulty")
                .GetValueAsync().ContinueWithOnMainThread(task => {
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
            AddPuzzleToDatabase(rawPuzzle);
        }

        private void AddPuzzleToDatabase(RawPuzzle rawPuzzle)
        {
            rawPuzzle.Key = _dBReference.Child("puzzles").Push().Key;
            string jsonPuzzle = JsonUtility.ToJson(rawPuzzle);
            var DBTask = _dBReference.Child("puzzles").Child(rawPuzzle.Key).SetRawJsonValueAsync(jsonPuzzle);
            
            //yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

            if (DBTask.Exception != null)
            {
                Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
            }
            else
            {
                //Deaths are now updated
            }
        }

        public void RemovePuzzle(string key)
        {
            FirebaseDatabase.DefaultInstance
                .GetReference("puzzles").Child(key).RemoveValueAsync();
        }
    }
}