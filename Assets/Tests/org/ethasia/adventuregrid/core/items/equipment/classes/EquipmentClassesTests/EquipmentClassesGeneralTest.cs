﻿using NUnit.Framework;
using Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes;
using Org.Ethasia.Adventuregrid.Core.Items.Equipment;

namespace Org.Ethasia.Adventuregrid.Core.Items.Equipment.Classes.EquipmentClassesTests
{
    public class EquipmentClassesGeneralTest
    {
        private EquipmentClass oneHandedSword;
        private EquipmentClass twoHandedSword;
        private EquipmentClass oneHandedMace;
        private EquipmentClass twoHandedMace;
        private EquipmentClass bow;
        private EquipmentClass crossBow;
        private EquipmentClass wand;
        private EquipmentClass magicStaff;
        private EquipmentClass shield;
        private EquipmentClass forceShield;
        private EquipmentClass arrowQuiver;
        private EquipmentClass boltQuiver;
        private EquipmentClass helmet;
        private EquipmentClass bodyArmor;
        private EquipmentClass pants;
        private EquipmentClass shoes;
        private EquipmentClass gloves;
        private EquipmentClass ring;
        private EquipmentClass amulet;

        [SetUp]
        public void SetUpEquipment()
        {
            oneHandedSword = new OneHandedSword();
            twoHandedSword = new TwoHandedSword();

            oneHandedMace = new OneHandedMace();
            twoHandedMace = new TwoHandedMace();

            bow = new Bow();
            crossBow = new CrossBow();

            wand = new Wand();
            magicStaff = new MagicStaff();

            shield = new Shield();
            forceShield = new ForceShield();

            arrowQuiver = new ArrowQuiver();
            boltQuiver = new BoltQuiver();

            helmet = new Helmet();
            bodyArmor = new BodyArmor();
            pants = new Pants();
            shoes = new Shoes();
            gloves = new Gloves();

            ring = new Ring();
            amulet = new Amulet();
        }

        [Test]
        public void TestThatOneHandedSwordCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new OneHandedSword();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }

        [Test]
        public void TestThatOneHandedMaceCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new OneHandedMace();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }     

        [Test]
        public void TestThatTwoHandedSwordCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new TwoHandedSword();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }        

        [Test]
        public void TestThatTwoHandedMaceCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new TwoHandedMace();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }         

        [Test]
        public void TestThatBowCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new Bow();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }   

        [Test]
        public void TestThatCrossbowCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new CrossBow();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        } 

        [Test]
        public void TestThatWandCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new Wand();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        } 

        [Test]
        public void TestThatMagicStaffCanBeEquippedInMainHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new MagicStaff();
            EquipInMainHandAndTestThatItIsOccupied(testCandidate);
        }    

        [Test]
        public void TestThatOneHandedSwordsCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedSword();

            TestThatMainHandEquipmentCanBeEquippedWithSword(testCandidate, playerEquipment);

            testCandidate = new OneHandedSword();
            TestThatMainHandEquipmentCanBeEquippedWithMace(testCandidate, playerEquipment); 

            testCandidate = new OneHandedSword();
            TestThatMainHandEquipmentCanBeEquippedWithWand(testCandidate, playerEquipment);                   
        }

        [Test]
        public void TestThatOneHandedMacesCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new OneHandedMace();

            TestThatMainHandEquipmentCanBeEquippedWithSword(testCandidate, playerEquipment);

            testCandidate = new OneHandedMace();
            TestThatMainHandEquipmentCanBeEquippedWithMace(testCandidate, playerEquipment); 

            testCandidate = new OneHandedMace();
            TestThatMainHandEquipmentCanBeEquippedWithWand(testCandidate, playerEquipment);       
        }   

        [Test]
        public void TestThatWandsCanBeEquippedWithOneHandedWeaponsInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Wand();

            TestThatMainHandEquipmentCanBeEquippedWithSword(testCandidate, playerEquipment);

            testCandidate = new Wand();
            TestThatMainHandEquipmentCanBeEquippedWithMace(testCandidate, playerEquipment); 

            testCandidate = new Wand();
            TestThatMainHandEquipmentCanBeEquippedWithWand(testCandidate, playerEquipment);                       
        } 

        [Test]
        public void TestThatOneHandedSwordsCanBeEquippedWithShieldsAndForceShields()
        {
            EquipmentClass firstTestCandidate = new OneHandedSword();
            EquipmentClass secondTestCandidate = new OneHandedSword();
            TestThatOneHandedWeaponCanBeEquippedWithShieldAndForceShield(firstTestCandidate, secondTestCandidate);                        
        }  

        [Test]
        public void TestThatOneHandedMacesCanBeEquippedWithShieldsAndForceShields()
        {
            EquipmentClass firstTestCandidate = new OneHandedMace();
            EquipmentClass secondTestCandidate = new OneHandedMace();
            TestThatOneHandedWeaponCanBeEquippedWithShieldAndForceShield(firstTestCandidate, secondTestCandidate);                                    
        } 

        [Test]
        public void TestThatWandsCanBeEquippedWithShieldsAndForceShields()
        {
            EquipmentClass firstTestCandidate = new Wand();
            EquipmentClass secondTestCandidate = new Wand();
            TestThatOneHandedWeaponCanBeEquippedWithShieldAndForceShield(firstTestCandidate, secondTestCandidate);                                      
        }    

        [Test]
        public void TestThatOneHandedSwordsCannotBeEquippedWithQuivers()
        {
            EquipmentClass firstTestCandidate = new OneHandedSword();
            EquipmentClass secondTestCandidate = new OneHandedSword();
            TestThatOneHandedWeaponCannotBeEquippedWithQuivers(firstTestCandidate, secondTestCandidate);                       
        }      

        [Test]
        public void TestThatOneHandedMacesCannotBeEquippedWithQuivers()
        {
            EquipmentClass firstTestCandidate = new OneHandedMace();
            EquipmentClass secondTestCandidate = new OneHandedMace();
            TestThatOneHandedWeaponCannotBeEquippedWithQuivers(firstTestCandidate, secondTestCandidate);                         
        }     

        [Test]
        public void TestThatWandsCannotBeEquippedWithQuivers()
        {
            EquipmentClass firstTestCandidate = new Wand();
            EquipmentClass secondTestCandidate = new Wand();
            TestThatOneHandedWeaponCannotBeEquippedWithQuivers(firstTestCandidate, secondTestCandidate);                                      
        }   

        [Test]
        public void TestThatTwoHandedSwordsCannotBeEquippedWithOffHands()
        {
            EquipmentClass testCandidate = new TwoHandedSword();
            TestThatTwoHandedWeaponsCannotBeEquippedWithOffHands(testCandidate);
        }      

        [Test]
        public void TestThatTwoHandedMacesCannotBeEquippedWithOffHands()
        {
            EquipmentClass testCandidate = new TwoHandedMace();
            TestThatTwoHandedWeaponsCannotBeEquippedWithOffHands(testCandidate);                                                                      
        }   

        [Test]
        public void TestThatMagicStaffsCannotBeEquippedWithOffHands()
        {
            EquipmentClass testCandidate = new MagicStaff();
            TestThatTwoHandedWeaponsCannotBeEquippedWithOffHands(testCandidate);                                                                          
        }     

        [Test]
        public void TestThatBowsCannotBeEquippedWithWeaponsOrShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new Bow();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new Bow();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new Bow();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new Bow();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new Bow();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            testCandidate = new Bow();
            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);          

            testCandidate = new Bow();
            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                                                                         
        }     

        [Test]
        public void TestThatCrossBowsCannotBeEquippedWithWeaponsOrShields()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass testCandidate = new CrossBow();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            testCandidate = new CrossBow();
            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            testCandidate = new CrossBow();
            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            testCandidate = new CrossBow();
            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            testCandidate = new CrossBow();
            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);                                                                                 
        }                                                                            

        [Test]
        public void TestThatNonWeaponsCannotBeEquippedInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            playerEquipment.EquipInMainHand(amulet);
            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(arrowQuiver);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(bodyArmor);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(boltQuiver);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(forceShield);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(gloves);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(helmet);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(pants);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(ring);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(shield);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(shoes);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);
        }    

        [Test]
        public void TestThatOneHandedSwordCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new OneHandedSword();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }  

        [Test]
        public void TestThatOneHandedMaceCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new OneHandedMace();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }            

        [Test]
        public void TestThatArrowQuiverCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new ArrowQuiver();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }    

        [Test]
        public void TestThatBoltQuiverCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new BoltQuiver();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }  

        [Test]
        public void TestThatShieldCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new Shield();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }   

        [Test]
        public void TestThatForceShieldCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new ForceShield();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }   

        [Test]
        public void TestThatWandCanBeEquippedInOffHandWithNothingPresent()
        {
            EquipmentClass testCandidate = new Wand();
            TestThatGivenEquipmentCanBeEequippedInOffHandSlot(testCandidate);
        }  

        [Test]
        public void TestThatOnlyOffHandsAndOneHandersCanBeEquippedInOffHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            playerEquipment.EquipInOffHand(amulet);
            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(bodyArmor);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(bow);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(crossBow);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);       

            playerEquipment.EquipInOffHand(gloves);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);   

            playerEquipment.EquipInOffHand(helmet);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);      

            playerEquipment.EquipInOffHand(magicStaff);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False); 

            playerEquipment.EquipInOffHand(pants);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);      

            playerEquipment.EquipInOffHand(ring);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);    

            playerEquipment.EquipInOffHand(shoes);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);  

            playerEquipment.EquipInOffHand(twoHandedMace);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);  

            playerEquipment.EquipInOffHand(twoHandedSword);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);                                                                                                             
        }   

        [Test]
        public void TestThatArrowQuiverCannotBeEquippedWhenNonBowIsInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass mainHandEquipment = new OneHandedSword();

            EquipmentClass offHand = new ArrowQuiver();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);

            mainHandEquipment = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);         

            mainHandEquipment = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);        

            mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                   
        } 

        [Test]
        public void TestThatBoltQuiverCannotBeEquippedWhenNonCrossBowIsInMainHand()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass mainHandEquipment = new OneHandedSword();

            EquipmentClass offHand = new BoltQuiver();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);

            mainHandEquipment = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);         

            mainHandEquipment = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);        

            mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(offHand);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(offHand));                                                                   
        }  

        [Test]
        public void TestThatShieldsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            EquipmentClass offHand = new Shield(); 
            EquipmentClass secondOffHandInstance = new Shield(); 
            TestThatOffHanderCanOnlyBeEquippedWithOneHander(offHand, secondOffHandInstance);                                                                       
        }

        [Test]
        public void TestThatForceShieldsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            EquipmentClass offHand = new ForceShield();     
            EquipmentClass secondOffHandInstance = new ForceShield(); 
            TestThatOffHanderCanOnlyBeEquippedWithOneHander(offHand, secondOffHandInstance);                                                            
        }   

        [Test]
        public void TestThatOffhandOneHandedSwordsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            EquipmentClass offHand = new OneHandedSword();   
            EquipmentClass secondOffHandInstance = new OneHandedSword(); 
            TestThatOffHanderCanOnlyBeEquippedWithOneHander(offHand, secondOffHandInstance);                                                                   
        }  

        [Test]
        public void TestThatOffhandOneHandedMacesCanOnlyBeEquippedWithOneHandedWeapons()
        {
            EquipmentClass offHand = new OneHandedMace();     
            EquipmentClass secondOffHandInstance = new OneHandedMace(); 
            TestThatOffHanderCanOnlyBeEquippedWithOneHander(offHand, secondOffHandInstance);                                                                                    
        } 

        [Test]
        public void TestThatOffhandWandsCanOnlyBeEquippedWithOneHandedWeapons()
        {
            EquipmentClass offHand = new Wand();    
            EquipmentClass secondOffHandInstance = new Wand(); 
            TestThatOffHanderCanOnlyBeEquippedWithOneHander(offHand, secondOffHandInstance);                                                                               
        } 

        [Test]
        public void TestThatOnlyHelmetsCanBeEquippedInHeadSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnHead(helmet);
            playerEquipment.EquipOnHead(oneHandedSword);
            playerEquipment.EquipOnHead(oneHandedMace);
            playerEquipment.EquipOnHead(wand);
            playerEquipment.EquipOnHead(twoHandedSword);
            playerEquipment.EquipOnHead(twoHandedMace);
            playerEquipment.EquipOnHead(bow);
            playerEquipment.EquipOnHead(crossBow);
            playerEquipment.EquipOnHead(magicStaff);
            playerEquipment.EquipOnHead(shield);
            playerEquipment.EquipOnHead(forceShield);
            playerEquipment.EquipOnHead(arrowQuiver);
            playerEquipment.EquipOnHead(boltQuiver);
            playerEquipment.EquipOnHead(bodyArmor);
            playerEquipment.EquipOnHead(pants);
            playerEquipment.EquipOnHead(shoes);
            playerEquipment.EquipOnHead(gloves);
            playerEquipment.EquipOnHead(ring);
            playerEquipment.EquipOnHead(amulet);

            bool isHeadSlotOccupied = playerEquipment.IsHeadSlotOccupied();
            EquipmentClass headEquipment = playerEquipment.GetHeadEquipment();  
            Assert.That(isHeadSlotOccupied, Is.True);
            Assert.That(headEquipment, Is.EqualTo(helmet));          
        } 

        [Test]
        public void TestThatOnlyBodyArmorsCanBeEquippedInChestSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnChest(bodyArmor);
            playerEquipment.EquipOnChest(oneHandedSword);
            playerEquipment.EquipOnChest(oneHandedMace);
            playerEquipment.EquipOnChest(wand);
            playerEquipment.EquipOnChest(twoHandedSword);
            playerEquipment.EquipOnChest(twoHandedMace);
            playerEquipment.EquipOnChest(bow);
            playerEquipment.EquipOnChest(crossBow);
            playerEquipment.EquipOnChest(magicStaff);
            playerEquipment.EquipOnChest(shield);
            playerEquipment.EquipOnChest(forceShield);
            playerEquipment.EquipOnChest(arrowQuiver);
            playerEquipment.EquipOnChest(boltQuiver);
            playerEquipment.EquipOnChest(helmet);
            playerEquipment.EquipOnChest(pants);
            playerEquipment.EquipOnChest(shoes);
            playerEquipment.EquipOnChest(gloves);
            playerEquipment.EquipOnChest(ring);
            playerEquipment.EquipOnChest(amulet);

            bool isChestSlotOccupied = playerEquipment.IsChestSlotOccupied();
            EquipmentClass chestEquipment = playerEquipment.GetChestEquipment();  
            Assert.That(isChestSlotOccupied, Is.True);
            Assert.That(chestEquipment, Is.EqualTo(bodyArmor));          
        }  

        [Test]
        public void TestThatOnlyPantsCanBeEquippedInLegSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnLegs(pants);
            playerEquipment.EquipOnLegs(oneHandedSword);
            playerEquipment.EquipOnLegs(oneHandedMace);
            playerEquipment.EquipOnLegs(wand);
            playerEquipment.EquipOnLegs(twoHandedSword);
            playerEquipment.EquipOnLegs(twoHandedMace);
            playerEquipment.EquipOnLegs(bow);
            playerEquipment.EquipOnLegs(crossBow);
            playerEquipment.EquipOnLegs(magicStaff);
            playerEquipment.EquipOnLegs(shield);
            playerEquipment.EquipOnLegs(forceShield);
            playerEquipment.EquipOnLegs(arrowQuiver);
            playerEquipment.EquipOnLegs(boltQuiver);
            playerEquipment.EquipOnLegs(helmet);
            playerEquipment.EquipOnLegs(bodyArmor);
            playerEquipment.EquipOnLegs(shoes);
            playerEquipment.EquipOnLegs(gloves);
            playerEquipment.EquipOnLegs(ring);
            playerEquipment.EquipOnLegs(amulet);

            bool isLegSlotOccupied = playerEquipment.IsLegSlotOccupied();
            EquipmentClass legEquipment = playerEquipment.GetLegEquipment();  
            Assert.That(isLegSlotOccupied, Is.True);
            Assert.That(legEquipment, Is.EqualTo(pants));          
        }  

        [Test]
        public void TestThatOnlyShoesCanBeEquippedOnFeet()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnFeet(shoes);
            playerEquipment.EquipOnFeet(oneHandedSword);
            playerEquipment.EquipOnFeet(oneHandedMace);
            playerEquipment.EquipOnFeet(wand);
            playerEquipment.EquipOnFeet(twoHandedSword);
            playerEquipment.EquipOnFeet(twoHandedMace);
            playerEquipment.EquipOnFeet(bow);
            playerEquipment.EquipOnFeet(crossBow);
            playerEquipment.EquipOnFeet(magicStaff);
            playerEquipment.EquipOnFeet(shield);
            playerEquipment.EquipOnFeet(forceShield);
            playerEquipment.EquipOnFeet(arrowQuiver);
            playerEquipment.EquipOnFeet(boltQuiver);
            playerEquipment.EquipOnFeet(helmet);
            playerEquipment.EquipOnFeet(bodyArmor);
            playerEquipment.EquipOnFeet(pants);
            playerEquipment.EquipOnFeet(gloves);
            playerEquipment.EquipOnFeet(ring);
            playerEquipment.EquipOnFeet(amulet);

            bool isFeetSlotOccupied = playerEquipment.IsFeetSlotOccupied();
            EquipmentClass feetEquipment = playerEquipment.GetFeetEquipment();  
            Assert.That(isFeetSlotOccupied, Is.True);
            Assert.That(feetEquipment, Is.EqualTo(shoes));          
        } 

        [Test]
        public void TestThatOnlyGlovesCanBeEquippedOnHands()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnHands(gloves);
            playerEquipment.EquipOnHands(oneHandedSword);
            playerEquipment.EquipOnHands(oneHandedMace);
            playerEquipment.EquipOnHands(wand);
            playerEquipment.EquipOnHands(twoHandedSword);
            playerEquipment.EquipOnHands(twoHandedMace);
            playerEquipment.EquipOnHands(bow);
            playerEquipment.EquipOnHands(crossBow);
            playerEquipment.EquipOnHands(magicStaff);
            playerEquipment.EquipOnHands(shield);
            playerEquipment.EquipOnHands(forceShield);
            playerEquipment.EquipOnHands(arrowQuiver);
            playerEquipment.EquipOnHands(boltQuiver);
            playerEquipment.EquipOnHands(helmet);
            playerEquipment.EquipOnHands(bodyArmor);
            playerEquipment.EquipOnHands(pants);
            playerEquipment.EquipOnHands(shoes);
            playerEquipment.EquipOnHands(ring);
            playerEquipment.EquipOnHands(amulet);

            bool isHandsSlotOccupied = playerEquipment.IsHandsSlotOccupied();
            EquipmentClass handsEquipment = playerEquipment.GetHandsEquipment();  
            Assert.That(isHandsSlotOccupied, Is.True);
            Assert.That(handsEquipment, Is.EqualTo(gloves));          
        } 

        [Test]
        public void TestThatOnlyRingsCanBeEquippedOnRightRingSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnRightRingSlot(ring);
            playerEquipment.EquipOnRightRingSlot(oneHandedSword);
            playerEquipment.EquipOnRightRingSlot(oneHandedMace);
            playerEquipment.EquipOnRightRingSlot(wand);
            playerEquipment.EquipOnRightRingSlot(twoHandedSword);
            playerEquipment.EquipOnRightRingSlot(twoHandedMace);
            playerEquipment.EquipOnRightRingSlot(bow);
            playerEquipment.EquipOnRightRingSlot(crossBow);
            playerEquipment.EquipOnRightRingSlot(magicStaff);
            playerEquipment.EquipOnRightRingSlot(shield);
            playerEquipment.EquipOnRightRingSlot(forceShield);
            playerEquipment.EquipOnRightRingSlot(arrowQuiver);
            playerEquipment.EquipOnRightRingSlot(boltQuiver);
            playerEquipment.EquipOnRightRingSlot(helmet);
            playerEquipment.EquipOnRightRingSlot(bodyArmor);
            playerEquipment.EquipOnRightRingSlot(pants);
            playerEquipment.EquipOnRightRingSlot(shoes);
            playerEquipment.EquipOnRightRingSlot(gloves);
            playerEquipment.EquipOnRightRingSlot(amulet);

            bool isRightRingSlotOccupied = playerEquipment.IsRightRingSlotOccupied();
            EquipmentClass rightRingEquipment = playerEquipment.GetRightRingEquipment();  
            Assert.That(isRightRingSlotOccupied, Is.True);
            Assert.That(rightRingEquipment, Is.EqualTo(ring));          
        }  

        [Test]
        public void TestThatOnlyRingsCanBeEquippedOnLeftRingSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
        
            playerEquipment.EquipOnLeftRingSlot(ring);
            playerEquipment.EquipOnLeftRingSlot(oneHandedSword);
            playerEquipment.EquipOnLeftRingSlot(oneHandedMace);
            playerEquipment.EquipOnLeftRingSlot(wand);
            playerEquipment.EquipOnLeftRingSlot(twoHandedSword);
            playerEquipment.EquipOnLeftRingSlot(twoHandedMace);
            playerEquipment.EquipOnLeftRingSlot(bow);
            playerEquipment.EquipOnLeftRingSlot(crossBow);
            playerEquipment.EquipOnLeftRingSlot(magicStaff);
            playerEquipment.EquipOnLeftRingSlot(shield);
            playerEquipment.EquipOnLeftRingSlot(forceShield);
            playerEquipment.EquipOnLeftRingSlot(arrowQuiver);
            playerEquipment.EquipOnLeftRingSlot(boltQuiver);
            playerEquipment.EquipOnLeftRingSlot(helmet);
            playerEquipment.EquipOnLeftRingSlot(bodyArmor);
            playerEquipment.EquipOnLeftRingSlot(pants);
            playerEquipment.EquipOnLeftRingSlot(shoes);
            playerEquipment.EquipOnLeftRingSlot(gloves);
            playerEquipment.EquipOnLeftRingSlot(amulet);

            bool isLeftRingSlotOccupied = playerEquipment.IsLeftRingSlotOccupied();
            EquipmentClass leftRingEquipment = playerEquipment.GetLeftRingEquipment();  
            Assert.That(isLeftRingSlotOccupied, Is.True);
            Assert.That(leftRingEquipment, Is.EqualTo(ring));          
        } 

        [Test]
        public void TestThatOnlyAmuletsCanBeEquippedOnAmuletSlot()
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            
            playerEquipment.EquipOnAmuletSlot(amulet);
            playerEquipment.EquipOnAmuletSlot(oneHandedSword);
            playerEquipment.EquipOnAmuletSlot(oneHandedMace);
            playerEquipment.EquipOnAmuletSlot(wand);
            playerEquipment.EquipOnAmuletSlot(twoHandedSword);
            playerEquipment.EquipOnAmuletSlot(twoHandedMace);
            playerEquipment.EquipOnAmuletSlot(bow);
            playerEquipment.EquipOnAmuletSlot(crossBow);
            playerEquipment.EquipOnAmuletSlot(magicStaff);
            playerEquipment.EquipOnAmuletSlot(shield);
            playerEquipment.EquipOnAmuletSlot(forceShield);
            playerEquipment.EquipOnAmuletSlot(arrowQuiver);
            playerEquipment.EquipOnAmuletSlot(boltQuiver);
            playerEquipment.EquipOnAmuletSlot(helmet);
            playerEquipment.EquipOnAmuletSlot(bodyArmor);
            playerEquipment.EquipOnAmuletSlot(pants);
            playerEquipment.EquipOnAmuletSlot(shoes);
            playerEquipment.EquipOnAmuletSlot(gloves);
            playerEquipment.EquipOnAmuletSlot(ring);

            bool isAmuletSlotOccupied = playerEquipment.IsAmuletSlotOccupied();
            EquipmentClass amuletEquipment = playerEquipment.GetAmuletEquipment();  
            Assert.That(isAmuletSlotOccupied, Is.True);
            Assert.That(amuletEquipment, Is.EqualTo(amulet));          
        } 

        private void EquipInMainHandAndTestThatItIsOccupied(EquipmentClass testCandidate)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            bool isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            Assert.That(isMainHandOccupied, Is.False);

            playerEquipment.EquipInMainHand(testCandidate);
            isMainHandOccupied = playerEquipment.IsMainHandOccupied();
            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();

            Assert.That(isMainHandOccupied, Is.True);
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));            
        }   

        private void TestThatMainHandEquipmentCanBeEquippedWithSword(EquipmentClass testCandidate, PlayerEquipmentSlots playerEquipment)
        {
            EquipmentClass offHandSword = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHandSword);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));            
        }

        private void TestThatMainHandEquipmentCanBeEquippedWithMace(EquipmentClass testCandidate, PlayerEquipmentSlots playerEquipment)
        {
            EquipmentClass offHandMace = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHandMace);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));             
        }

        private void TestThatMainHandEquipmentCanBeEquippedWithWand(EquipmentClass testCandidate, PlayerEquipmentSlots playerEquipment)
        {
            EquipmentClass offHandWand = new Wand();

            playerEquipment.EquipInOffHand(offHandWand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(testCandidate));                
        }    

        private void TestThatOneHandedWeaponCanBeEquippedWithShieldAndForceShield(EquipmentClass equipmentWithShield, EquipmentClass equipmentWithForceShield)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass shield = new Shield();

            playerEquipment.EquipInOffHand(shield);
            playerEquipment.EquipInMainHand(equipmentWithShield);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(equipmentWithShield));

            EquipmentClass forceShield = new ForceShield();

            playerEquipment.EquipInOffHand(forceShield);
            playerEquipment.EquipInMainHand(equipmentWithForceShield);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.EqualTo(equipmentWithForceShield));  
        } 

        private void TestThatOneHandedWeaponCannotBeEquippedWithQuivers(EquipmentClass equipmentWithQuiver, EquipmentClass equipmentWithBoltQuiver)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass arrowQuiver = new ArrowQuiver();

            playerEquipment.EquipInOffHand(arrowQuiver);
            playerEquipment.EquipInMainHand(equipmentWithQuiver);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            EquipmentClass boltQuiver = new BoltQuiver();

            playerEquipment.EquipInOffHand(boltQuiver);
            playerEquipment.EquipInMainHand(equipmentWithBoltQuiver);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);    
        }   

        private void TestThatTwoHandedWeaponsCannotBeEquippedWithOffHands(EquipmentClass testCandidate)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();
            EquipmentClass offHand = new OneHandedSword();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            EquipmentClass mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);

            offHand = new OneHandedMace();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null); 

            offHand = new Wand();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);             

            offHand = new Shield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);   

            offHand = new ForceShield();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);     

            offHand = new ArrowQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);  

            offHand = new BoltQuiver();

            playerEquipment.EquipInOffHand(offHand);
            playerEquipment.EquipInMainHand(testCandidate);

            mainHandEquipment = playerEquipment.GetMainHandEquipment();
            Assert.That(mainHandEquipment, Is.Null);              
        }  

        private void TestThatGivenEquipmentCanBeEequippedInOffHandSlot(EquipmentClass testCandidate)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();

            bool isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            Assert.That(isOffHandOccupied, Is.False);

            playerEquipment.EquipInOffHand(testCandidate);
            isOffHandOccupied = playerEquipment.IsOffHandOccupied();
            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(isOffHandOccupied, Is.True);
            Assert.That(offHandEquipment, Is.EqualTo(testCandidate));
        } 

        private void TestThatOffHanderCanOnlyBeEquippedWithOneHander(EquipmentClass firstOffHanderInstance, EquipmentClass secondOffHanderInstance)
        {
            PlayerEquipmentSlots playerEquipment = new PlayerEquipmentSlots();       

            EquipmentClass mainHandEquipment = new TwoHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            EquipmentClass offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);    

            mainHandEquipment = new TwoHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null); 

            mainHandEquipment = new MagicStaff();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new Bow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);  

            mainHandEquipment = new CrossBow();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.Null);      

            mainHandEquipment = new OneHandedSword();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(firstOffHanderInstance));

            mainHandEquipment = new OneHandedMace();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(secondOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(secondOffHanderInstance));       

            mainHandEquipment = new Wand();

            playerEquipment.EquipInMainHand(mainHandEquipment);
            playerEquipment.EquipInOffHand(firstOffHanderInstance);

            offHandEquipment = playerEquipment.GetOffHandEquipment();

            Assert.That(offHandEquipment, Is.EqualTo(firstOffHanderInstance));            
        }
    }
}