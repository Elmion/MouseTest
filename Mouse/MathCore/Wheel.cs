using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCore
{
    public class Wheel
    {


        public float Acceleration { get; set; }
        public float Mass
        {
            set
            {
                _mass = value;
                _inertia = (float)(_mass * Math.Pow(_radius, 2));
            }
        }
        public float Radius
        {
            set
            {
                _radius = value;
                _inertia = (float)(_mass * Math.Pow(_radius, 2));
            }
        }

        public float MaxSpeed { get; set; }
        public float AngleSpeed { get; set; }

        private float _inertia;
        private float _mass;
        private float _radius;
        private Mouse _currentMouse;
        private IProductBlock BlockConnected;

        public Wheel(float m,float r)
        {
           _mass = m;
           _radius = r;
           _inertia = (float)(_mass * Math.Pow(_radius, 2));
        }

        public void SpeedUp()
        {
            AngleSpeed += Acceleration;
        }
        public void ConnectBlock(IProductBlock block)
        {
            BlockConnected = block;
        }
        public void Update()
        {
            AngleSpeed = AngleSpeed * 0.99f;
            if (BlockConnected != null && ConsumePower(BlockConnected.NeedPower, 1))
            {
                BlockConnected.EnablePower = true;
            }
            else
            {
                BlockConnected.EnablePower = false;
            }
        }
        public void PutMouse(Mouse mouse)
        {
            _currentMouse = mouse;
        }
        public void GetAcceletate()
        {
            AngleSpeed = (AngleSpeed * _inertia + _currentMouse.PowerOUT()) / _inertia;
        }
        public bool ConsumePower(float powerOut,float deltaTime)
        {

            var bufAngleSpeed = (AngleSpeed * _inertia - powerOut * deltaTime) / _inertia;
            if (bufAngleSpeed > 0)
            {
                AngleSpeed = bufAngleSpeed;
                return true;
            }
            return false;
        }
    }
}
