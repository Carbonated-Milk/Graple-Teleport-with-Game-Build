using System;
using UnityEngine;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        public float speed = 5;
        [HideInInspector]public float distanceTravelled;
        public float offset;
        public bool rotate;

        public int coppies;
        private bool original = true;

        void Start() {
            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

            if (coppies > 1 && original)
            {
                float pathLength = pathCreator.path.length;
                for (int i = 1; i <= coppies; i++)
                {
                    GameObject newPlat = Instantiate(gameObject);
                    newPlat.GetComponent<PathFollower>().SetDist(i * pathLength / coppies);
                }
            }

            distanceTravelled += offset;
        }

        private void SetDist(float extraDist)
        {
            distanceTravelled += extraDist;
            original = false;
        }

        void FixedUpdate()
        {
            if (pathCreator != null)
            {
                distanceTravelled += speed * Time.fixedDeltaTime;
                transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                if(rotate)
                {
                    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
                }
            }
        }

        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged() {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
    }
}