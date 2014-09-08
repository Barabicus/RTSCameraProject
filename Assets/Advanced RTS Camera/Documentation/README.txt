Introduction:
		Advanced RTS Camera is designed to be powerful yet very easy to use with no programming knowledge required.
	The Camera was designed with RTS/Top down games in mind but could be easily configured for use with other games.
		Advanced RTS Camera is simple single drag and drop script that you should place onto your desired camera.
		From there you can configure the camera to meet your needs. The inspector for Advanced RTS Camera is grouped into 3 categories
		"Controls", "Behaviour", "Camera Configuration". 
			-Controls: Here you specify the input controls. The inputs can be either set to a axis defined in Unity's own Input window or a keycode
			which you can specify yourself.
			-Behaviour: Here you can define behaviour for your camera such as automatically adjusting to ground height or following a specified transform etc.
			-Camera Configuration: Here you specify general camera configuration options such as speed, tilt speed, max & min height etc.

		 Features of the RTS Camera include:
		-Highly flexible control setup
		-Standard movement controls, tilting, rotation, specified directional movments
		-Auto adjusting tilt to height using a set height or height above terrain methods
		-Smooth position, rotation, tilting movements.
		-Camera position auto moving above ground level using two method (Change Height or Preserve Height)
		-Transform following and transform look at
		-Edge Scrolling
		-General Camera Configuration eg: speed, rotate speed, tilt speed, tilt max & min height, min & max height
		-Cloud overlay

Features:
	-Controls
		The controls have been designed so that you can easily specify if you want to use a custom axis or specify keycodes. For the Vertical, Horizontal, Tilt,
		Rotate and Directional controls you can use either a "Axis" setup or a "KeyCode" setup. Using the axis setup you will be prompted to enter the name
		of your axis for example for the Vertical Axis uses "Vertical" by default. "Vertical" is a default unity input relating to the W & S keys. If you do
		choose to use an Axis be sure that the Axis exists otherwise exceptions will be thrown. If you choose to use a keycode your will be prompted to
		selected a key for the positive and negative inputs. You may select a key from the drop down menu that will appear.

		-Vertical
			This control relates to the vertical movements of the camera i.e. backward and forward movements.

		-Horizontal
			This control relates to horizontal movements of the camera i.e. left and right movements

		-Rotate
			This control relates to how the camera will move around the Y Axis i.e. rotating left and right

		-Tilt
			This control relates to how the camera will move aorund the X Axis i..e tilting up and down

		-Directional
			This control is a bit different to the other controls. Using directional you can specify a direction for the camera to move. This is useful 
			for creating cameras that move up and down or appear to zoom in. By default this Camera will use the Mouse Scrollwheel. The positive input
			on the mouse scrollwheel is forward movements so a direction of (0,-1,0) will make the camera drop when the mouse scrollwheel is moved forward
			similiary it will cause the inverse and cause the camera to climb when the mouse scrollwheel is moved backwards. Specifying a direction of (0, -1, 1)
			will create a zoom in effect causing the camera to both drop and moveforward when responding to positive input.

		-Middle Mouse Controls
			This control is different yet again. It works when the user holds down the middle mouse button and uses Mouse X and Mouse Y (this can be changed) axes
			as input. To actually deicde what the Mouse X and the Mouse Y inputs control you can select it via the Mouse X Controls and the Mouse Y Controls.
			From the drop down you can select "Vertical, Horizontal, Tilt, Rotate and Directional". This allows us to perform any of the previously stated movements
			using the axes specified. Setting Mouse X Control to Horizontal and Mouse Y Control to Vertical will create a drag effect where you can control the
			camera's position with the mouse. Similiary if you set Mouse X Control to Rotate and Mouse Y control to tilt you can control the entire rotation of
			the camera with the mouse. For ease of access you can invert the inputs via the "Invert Mouse X and Invert Mouse Y" toggles. Note by default the Mouse X
			axis responds to input by the mouse moving left and right while Mouse Y responds to input of the mouse moving backward and forward.

		-Behaviours
			Behaviours control certain aspects about how the camera should behave depending on certain variables.

			-Tilt Auto Adjust
				The Tilt Auto Adjust behaviour will adjust the Camera's tilt when it is near the ground. This behaviour has two methods "Distance To Ground"
				 and "Height". As with both methods you adjust their respective animation curve to control how fast they tilt at given heights. The Y axis of the
				 animation curve signifies height and the X axis signifies percent of current Tilt. A value of 0 will adjust the camera to the minimum tilt.
					-Distance to ground
						This method works when the height "above" the terrain is lower than the "Adjust At Distance To Ground" value, at this point the tilt is at
						100% of the current tilt, the closer it gets to the minimum height "above" the ground, the closer the tilt starts to adjust
						to the low tilt. Essentially it starts adjusting the tilt at the user specified distance above the ground and finishes adjusting
						at the minimum height the camera can be above the ground i.e. min height.
					-Height
						Unlike Distance to ground this method of tilting the camera does not consider height above ground level. It simply has two values
						"Finish Adjusting At" and "Start Adjusting At" simply put the camera will start adjusting at the latter and finish adjusting at the former.
						The height is in relative position to the camera height and not height above the ground.

		-Smooth Adjust
			Smooth adjust will smooth the Camera's position, rotation or tilt depending on the provided values. The greater the value the faster the camera
			will adjust. If Smooth adjust is disabled no smoothning will be applied. Note Unit's Input Axis can appear to smooth values depending on the setup. 
			This method will adjust the camera regardless of the current input.

		-Height Adjust
			The minimum height value is based off height to Terrain, while moving over the terrain if the Camera moves over a point where it should be adjusted
			to increase it's Y position the height adjust will adjust the height based on two different states
				-Preserve Height
					This method will attempt to preserve the Camera's current height position while moving over the terrain. If it moves over a point where the camera
					should be adjusted upwards, the camera will be adjust upwards however as soon as a lower point comes along the camera will adjust back down
					to the original position to the height where the height adjustment was performed last.
				-Change Height
					This method will not attempt to preserve the height and move back down when it can, rather it will adjust the height
					to the new high position when it moves over a higher point.

		-Follow Transform
			By providing the value labeled "Target To Follow" a transform you can follow and look at that target. You must first toggle to appropriate options for
			this to occur however. Simply providing a target will not actually do anything if no options are ticked.
				-Should Follow Target
					If a target is specified, the camera will attempt to follow it. The camera will be placed at the targets position plus the offset from the target
					specified via "Target Offset".
				-Look At Target
					If a target is specified and this is toggled the camera will point towards the target.
				-Movement Adjusts Offset
					In some cases you may wish to move around while still following your target. If this option is toggled it will allow the camera to move
					around as if it had no target, the only difference however is the movements the camera does while this is active will adjust the position
					offset to the target. If this option is not toggled the Camera will be unabled to move. Note: all movements while this option is toggled
					will perform exactly as if the camera was not following a target, they will simply adjust the position offset instead. 

		-Edge Scrolling
			Edge scrolling will allow vertical and horizontal movements when the mouse moves off screen. 
				-Scroll Speed X
					This relates to the width of the screen and is similiar to movement speed except it will only occur when either the mouse moves to the far left
					or to the far right.
				-Scroll Speed Y
					likewise this related to the height of the screen and will only occur when either mouse moves to the top or the bottom of the screen.

		-Clouds
			A cloud overlay can be drawn onto the screen if the Camera moves too high. The cloud Overlay has two draw states, these specify conditions when to
			actually begin drawing the overlay. Both methods include a "Cloud Max Transparency" option. This is the max transparency the overlay should be
			when the cloud reaches the max height of either states.
				-Percent Of Max Height
					This has two options "Start At Height Percent" and "End At Height Percent" these simply mean at what percent of max height should the camera
					begin drawing the clouds and at what percent of max height should it finish. At "Start At Height Percent" the overlay alpha will be 0 while at
					"Finish At Height Percent" the overlay alpha will be the alpha specified in "Cloud Max Transparency".
				-At Height
					Rather than specifying a percent to start drawing the clouds you can specify specific heights. This acts just like Percent of Max Height except
					the two numbers do not relate to a percent of the MaxHeight, they relate to the y position of the camera instead.

	-Camera Configuration
		This section just contains general variables relating to the camera.

			-Movement Speed
				This is the movement speed of the camera for the Vertical And Horizontal movements
			
			-Rotate Speed
				This is how fast the Camera should rotate around the Y axis i.e. rotating left and right

			-Tilt Speed
				This is how fast the camera should tilt up and down

			-Min Tilt
				This is the minimum tilt of the camera. If you want your camera to be able to completely rotate up and rotate down this value should be set to
				-90 if you want the minimum rotation of the camera to be looking straight ahead, this should be 0
			
			-Max Tilt
				This is the maximum tilt the camera can rotate to. This value should be greater than Min tilt. If you want your camera to be able to look completely
				down this should be set to a value of 90

			-Delta Time Ignores TimeScale
				If you are creating a game where you manipulate the timescale to perform action faster, this can have the undesirable affect of moving the camera
				much faster as well when really all you want to move faster is the gameplay. Ticking this option negates the TimeScale from the Camera's delta time
				and will perform movements on the Camera as if TimeScale was set to 1.

			-Ground Layer
				This should be set to your ground layer. The camera will only interact with GameObjects that is set to this layer. This includes Auto rotation and
				position offsets.
