using UnityEngine;
using UnityEngine.Playables;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Timeline")]
	[Tooltip("Play Unity timeline. This action requires Unity 2017.1 or above.")]

	public class  playTimeline : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(PlayableDirector))]
		[Tooltip("The game object to hold the unity timeline components.")]
		public FsmOwnerDefault gameObject;

		[Tooltip("Check this box to preform this action every frame.")]
		public FsmBool everyFrame;

        [ObjectType(typeof(PlayableAsset))]
        public FsmObject playableObject;


        [ObjectType(typeof(DirectorWrapMode))]
        public FsmEnum wrapMode;

        private PlayableDirector timeline;

		public override void Reset()
		{

			gameObject = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			timeline = go.GetComponent<PlayableDirector>();

			if (!everyFrame.Value)
			{
				timelineAction();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				timelineAction();
			}
		}

		void timelineAction()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

            if (playableObject.Value != null )
                timeline.Play((PlayableAsset)playableObject.Value, (DirectorWrapMode)wrapMode.Value);
            else 
    			timeline.Play();
		}

	}
}