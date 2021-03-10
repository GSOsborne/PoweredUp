/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID DSP_CHORUS = 601907247U;
        static const AkUniqueID DSP_DISTORTION = 3416339456U;
        static const AkUniqueID DSP_ECHO = 448578474U;
        static const AkUniqueID DSP_TREMELO = 1117646869U;
        static const AkUniqueID EXTRAOFF = 1925712768U;
        static const AkUniqueID EXTRAON = 2154843210U;
        static const AkUniqueID STARTWINDSONG = 3323822450U;
        static const AkUniqueID STOPWINDSONG = 440804120U;
        static const AkUniqueID WINDBUILD = 2550887757U;
        static const AkUniqueID WINDEXPLORE = 3262533912U;
        static const AkUniqueID WINDLAYER1 = 4082814115U;
        static const AkUniqueID WINDLAYER2 = 4082814112U;
        static const AkUniqueID WINDLAYER3 = 4082814113U;
        static const AkUniqueID WINDLAYER4 = 4082814118U;
        static const AkUniqueID WINDTRIUMPH = 2440479920U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace DSPSTATE
        {
            static const AkUniqueID GROUP = 3097867629U;

            namespace STATE
            {
                static const AkUniqueID CHORUS = 2866621671U;
                static const AkUniqueID DISTORTION = 1517463400U;
                static const AkUniqueID ECHO = 713277698U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TREMELO = 4124907981U;
            } // namespace STATE
        } // namespace DSPSTATE

        namespace GESTURESTINGER
        {
            static const AkUniqueID GROUP = 3958274164U;

            namespace STATE
            {
                static const AkUniqueID EXTRAOFF = 1925712768U;
                static const AkUniqueID EXTRAON = 2154843210U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace GESTURESTINGER

        namespace WINDEXPLORELAYER
        {
            static const AkUniqueID GROUP = 2348974095U;

            namespace STATE
            {
                static const AkUniqueID LAYER1 = 3298531297U;
                static const AkUniqueID LAYER2 = 3298531298U;
                static const AkUniqueID LAYER3 = 3298531299U;
                static const AkUniqueID LAYER4 = 3298531300U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace WINDEXPLORELAYER

        namespace WINDSTATE
        {
            static const AkUniqueID GROUP = 3313638542U;

            namespace STATE
            {
                static const AkUniqueID BUILDING = 3339761385U;
                static const AkUniqueID EXPLORING = 1823678183U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID TRIUMPHANT = 1703190205U;
            } // namespace STATE
        } // namespace WINDSTATE

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID HUBWORLD = 2267626510U;
        static const AkUniqueID WIND = 1537061107U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUX_BUSSES
    {
        static const AkUniqueID DSPEFFECTSEND = 3050122115U;
        static const AkUniqueID REVERBSEND = 1572469619U;
    } // namespace AUX_BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
